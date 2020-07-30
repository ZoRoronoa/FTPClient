using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace FTP
{
    public class FtpClient
    {
        #region 构造函数
        // 缺省构造函数
        public FtpClient()
        {
            strReHost = "";
            strRePath = "/";
            strReUser = "";
            strRePass = "";
            strRePort = 21;
            bConnected = false;
        }

        public FtpClient(string reHost, string rePath, string reUser, string rePass, int rePort)
        {
            strReHost = reHost;
            strRePath = rePath;
            strReUser = reUser;
            strRePass = rePass;
            strRePort = rePort;
            Connect();
        }
        #endregion


        #region 登陆
        // FTP服务器IP地址
        public int percentage;
        private string strReHost;
        public string ReHost
        {
            get
            {
                return strReHost;
            }
            set
            {
                strReHost = value;
            }
        }

        // FTP服务器端口
        private int strRePort;
        public int RePort
        {
            get
            {
                return strRePort;
            }
            set
            {
                strRePort = value;
            }
        }
        // 当前服务器目录
        private string strRePath;
        public string RePath
        {
            get
            {
                return strRePath;
            }
            set
            {
                strRePath = value;
            }
        }
        // 登录用户账号
        private string strReUser;
        public string ReUser
        {
            set
            {
                strReUser = value;
            }
        }
        // 用户登录密码
        private string strRePass;
        public string RePass
        {
            set
            {
                strRePass = value;
            }
        } 
          // 是否登录
        private Boolean bConnected;
        public bool Connected
        {
            get
            {
                return bConnected;
            }
        }
        #endregion


        #region 链接
        // 与服务器建立连接 
        public void Connect()
        {
            socketControl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endp = new IPEndPoint(IPAddress.Parse(ReHost), strRePort);
            // 链接
            try
            {
                socketControl.Connect(endp);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect to remote server");
            }   
            // 获取应答码
            ReadReply();
            if (iReplyCode != 220)//应答码220 新用户服务准备就绪 
            {
                DisConnect();
                throw new IOException(strReply.Substring(4));
            }   // 登陆
            SendCommand("USER " + strReUser);//命令 用户登录
            if (!(iReplyCode == 331 || iReplyCode == 230))//331 用户名称正确  230 用户登录
            {
                CloseSocketConnect();//关闭连接   若用户名称错误或登录失败
                throw new IOException(strReply.Substring(4));
            }
            if (iReplyCode != 230)//若用户未登录
            {
                SendCommand("PASS " + strRePass);//命令 系统登陆密码
                if (!(iReplyCode == 230 || iReplyCode == 202))//202 命令未实现
                {
                    CloseSocketConnect();//关闭连接
                    throw new IOException(strReply.Substring(4));
                }
            }
            // 若登陆成功，登陆状态bconneted更改为true，切换到登录目录
            bConnected = true;   
            ChDir(strRePath);
        }
        // 断开连接
        public void DisConnect()
        {
            if (socketControl != null)
            {
                SendCommand("QUIT");//命令 退出登录
            }
            CloseSocketConnect();
        }
        #endregion


        #region 传输模式 
        public enum TransferType { ASCII,Binary };//选择使用 ASCII传输方式或 Binary传输方式
        public void SetTransferType(TransferType tType)
        {

            if (tType == TransferType.Binary)//如果选择Binary传输方式
            {
                SendCommand("TYPE I");//binary类型传输
            }
            else
            {
                SendCommand("TYPE A");//ASCII类型传输
            }
            if (iReplyCode != 200)//若命令不成功命令成功
            {
                throw new IOException(strReply.Substring(4));
            }
            else
            {
                trType = tType;
            }
        }
        //获取当前传输模式
        public TransferType GetTransferType()
        {
            return trType;
        }
        #endregion

        
        #region 文件操作

        // 获得文件列表
        public string[] getlist(string strMask)//strMask 指定目录
        {
            // 建立链接
            if (!bConnected)
            {
                Connect();
            }   
            //建立进行数据连接的socket
            Socket socketData = CreateDSocket();

            //传送命令
            //详细信息
            SendCommand("LIST " + strMask);   //分析应答代码    NLST:列出指定目录内容
            if (!(iReplyCode == 150 || iReplyCode == 125 || iReplyCode == 226))//125： 连接打开准备传送  150： 打开数据连接 226:关闭数据连接，请求的文件操作成功 
            {
                throw new IOException(strReply.Substring(4));
            }   //获得结果
            strMsg = "";
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                // System.Text.Encoding.Unicode.GetString
                //strMsg += ASCII.GetString(buffer, 0, iBytes);
                strMsg += Encoding.UTF8.GetString(buffer, 0, iBytes);
                //MessageBox.Show(strMsg);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            //MessageBox.Show(strMsg);
            //char[] seperator = { '\n' };
            string[] seperator = { "\r\n" };
            string[] strsFileList = strMsg.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            Debug.WriteLine(strMsg);
            socketData.Close();//数据socket关闭时也会有返回码
            if (iReplyCode != 226)//226:关闭数据连接，请求的文件操作成功 
            {
                ReadReply();
                if (iReplyCode != 226)//226:关闭数据连接，请求的文件操作成功 
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
            return strsFileList;
        }
        // 获取文件大小
        private long GetFileSize(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("SIZE " + Path.GetFileName(strFileName));
            long lSize = 0;
            if (iReplyCode == 213)//213： 文件状态
            {
                lSize = Int64.Parse(strReply.Substring(4));
            }
            else
            {
                return -1;
            }
            return lSize;
        }

        // 删除文件
        public void Delete(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("DELE " + strFileName);
            if (iReplyCode != 250)//250： 请求的文件操作完成 
            {
                throw new IOException(strReply.Substring(4));
            }
        }
        // 重命名
        public void Rename(string strOFileName, string strNFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            try
            {
                SendCommand("RNFR " + strOFileName);//RNFR:对旧路径重命名
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            if (iReplyCode != 350)// 350 请求的文件需要进一步的操作
            {
                throw new IOException(strReply.Substring(4));
            }
            SendCommand("RNTO " + strNFileName);//RNTO:对新路径重命名
            if (iReplyCode != 250) //250： 请求的文件操作完成
            {
                throw new IOException(strReply.Substring(4));
            }
        }

        //显示当前工作目录
        public string PWD()
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("PWD");//PWD 显示当前工作目录
            if (iReplyCode == 250 || iReplyCode == 257)//250： 请求的文件操作完成 257： 创建"PATHNAME" 
            {

                return strReply.Split('\"')[1];
            }
            else
            {
                throw new IOException(strReply.Substring(4));
            }
        }
        #endregion


        #region 上传和下载

        public bool flag = false;
        public bool ReturnFlag()
        {
            return flag;
        }

        // 下载一个文件
        public void Download(string strRemoteFileName, string strFolder, string strLocalFileName,int BP)//参数 服务器传输的文件名 传输的文件目录 传输的本地文件名 断点位置
        {
            percentage = 0;
            if (!bConnected)
            {
               Connect();
            }
            SetTransferType(TransferType.Binary);//设置传输模式为binary
            if (strLocalFileName.Equals(""))//设置本地传输文件名 与服务器上要传输的文件名字相同
            {
                strLocalFileName = strRemoteFileName;
            }
            FileInfo localfileInfo = new FileInfo(strFolder + "\\" + strLocalFileName);
            long remotefileSize = GetFileSize(strRemoteFileName);
            if (!File.Exists(strFolder+"\\"+strLocalFileName)  )
            {
                FileStream output = new FileStream(strFolder + "\\" + strLocalFileName, FileMode.Create);
                Socket socketData = CreateDSocket();//创建数据socket
                SendCommand("RETR " + strRemoteFileName);//RETR命令 
                if (!(iReplyCode == 150 || iReplyCode == 125 || iReplyCode == 226 || iReplyCode == 250))//150 打开数据连接 125 打开数据连接开始传输 226 结束数据传输 250 操作完成
                {
                    throw new IOException(strReply.Substring(4));
                    //MessageBox.Show(strReply.Substring(4));
                }
                while (true)
                {
                    int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                    output.Write(buffer, 0, iBytes);
                    BP++;            //断点增加部分1
                    // 百分比
                    Console.WriteLine("TEST: " +BP + " "+ (double)512.0* BP/ remotefileSize );
                    percentage = 512 * BP;
                    // Program.curForm.label9.Text = percentage < 1 ? (percentage*100).ToString() : "100.00";
                    // Console.WriteLine(remotefileSize);
                    if ((iBytes <= 0) || (ReturnFlag() == true))
                    {
                        break;
                    }
                }

                output.Close();

                if (socketData.Connected)
                {
                    socketData.Close();
                }
                if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                {
                    ReadReply();
                    if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                    {
                        throw new IOException(strReply.Substring(4));
                    }
                }

            }
            //
            else
            {
                // long remotefileSize = GetFileSize(strRemoteFileName);
               
                long localfileSize = localfileInfo.Length;

                if (localfileSize != remotefileSize)
                {
                    flag = true;
                    downloadfrombp(strRemoteFileName, strFolder, localfileSize);
                    //return 2;
                }
                /*else
                {
                    flag = false;
                    BP = 0;
                }*/
            }
            
            //else downloadfrombp(strRemoteFileName, strFolder, (int)GetFileSize(strLocalFileName));
        }
        //下载 添加断点续传功能
        public void downloadfrombp(string strFileName,string strFolder,long BP)
        {
            if (!bConnected)
            {
                Connect();
            }
            FileStream output = new FileStream(strFolder + "\\" + strFileName, FileMode.Append);
            Socket socketData = CreateDSocket();//创建数据socket
            SendCommand("REST " + BP.ToString());//REST 由特定偏移量重启文件传递
            if (!(iReplyCode == 350))//350： 下一步命令 
            {
                throw new IOException(strReply.Substring(4));
            }
            
            SendCommand("RETR " + strFileName);//RETR 从服务器上找回（复制）文件
            if (!(iReplyCode == 150 || iReplyCode == 125 || iReplyCode == 226 || iReplyCode == 250))//150 打开数据连接 125 打开数据连接开始传输 226 结束数据传输 250 操作完成
            {
                throw new IOException(strReply.Substring(4));
            }
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, iBytes);
                if (iBytes <= 0)
                {
                    break;
                }
            }
            output.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
        }



        // 上传一个文件

        public void Upload(string strFileName,string strFolder)
        {
            if (!bConnected)
            {
                Connect();
            }
            if (GetFileSize(strFileName) == -1)
            {

                Socket socketData = CreateDSocket();
                SendCommand("STOR " + Path.GetFileName(strFileName)); 
                if (!(iReplyCode == 125 || iReplyCode == 150))//125： 连接打开准备传送 150： 打开数据连接
                {
                    throw new IOException(strReply.Substring(4));
                }
                FileStream input = new FileStream(strFileName, FileMode.Open);
                int iBytes = 0;
                while ((iBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    socketData.Send(buffer, iBytes, 0);
                }
                input.Close();
                if (socketData.Connected)
                {
                    socketData.Close();
                }
                if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                {
                    ReadReply();
                    if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                    {
                        throw new IOException(strReply.Substring(4));
                    }
                }
            
        }
            else
            {
                long remotefilesize = GetFileSize(strFileName);
                FileInfo localfileInfo = new FileInfo(strFolder + "\\" + Path.GetFileName(strFileName));
                long localfileSize = localfileInfo.Length;
                if(remotefilesize< localfileSize)
                {
                    UploadfromBP(strFileName, remotefilesize);
                }
            }
        }
        //上传 增加断点续传功能
        public void UploadfromBP(string strFileName,long BP)
        {
            if (!bConnected)
            {
                Connect();
            }           
            Socket socketData = CreateDSocket();
            SendCommand("REST " + BP.ToString());
            if (!(iReplyCode == 350))//350： 下一步命令 
            {
                throw new IOException(strReply.Substring(4));
            }
            SendCommand("STOR " + Path.GetFileName(strFileName));
            if (!(iReplyCode == 125 || iReplyCode == 150))//125： 连接打开准备传送 150： 打开数据连接
            {
                throw new IOException(strReply.Substring(4));
            }
            if (!(iReplyCode == 125 || iReplyCode == 150))//125： 连接打开准备传送 150： 打开数据连接
            {
                throw new IOException(strReply.Substring(4));
            }
            FileStream input = new FileStream(strFileName, FileMode.Open);
            input.Seek(BP, SeekOrigin.Begin);
            int iBytes = 0;
            while ((iBytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                socketData.Send(buffer, iBytes, 0);
            }
            input.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))//226 关闭数据连接，请求的文件操作成功  250  请求的文件操作完成
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
        }


        #endregion
        
        
        #region 目录操作
        // 创建目录
        public void MkDir(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("MKD " + strDirName);//MKD 在服务器上建立指定目录
            if (iReplyCode != 257)// 257 路径名已建立  若未建立路径
            {
                throw new IOException(strReply.Substring(4));
            }
        }

        // 删除目录
        public void RmDir(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("RMD " + strDirName);//RMD 在服务器上删除指定目录
            if (iReplyCode != 250)//250 请求的文件操作完成 
            {
                throw new IOException(strReply.Substring(4));
            }
        }

        // 改变目录
        public void ChDir(string strDirName)
        {
            if (strDirName.Equals(".") || strDirName.Equals(""))
            {
                return;
            }
            if (!bConnected)
            {
                Connect();
            }
            //MessageBox.Show(strDirName);
           
            SendCommand("CWD " + strDirName);//CWD 改变服务器上的工作目录
            if (iReplyCode != 250)// 250  请求的文件操作完成
            {
                throw new IOException(strReply.Substring(4));
            }
            this.strRePath = strDirName;
        }

        #endregion
        
        
        #region 内部变量
        // 服务器返回的应答信息(包含应答码)
        private string strMsg;
        // 服务器返回的应答信息(包含应答码)
        private string strReply;
        // 服务器返回的应答码
        private int iReplyCode;
        // 进行控制连接的socket
        private Socket socketControl;
        // 传输模式
        private TransferType trType;
        // 接收和发送数据的缓冲区
        // 每次发送512字节
        private static int BLOCK_SIZE = 512;
        Byte[] buffer = new Byte[BLOCK_SIZE];
        // 编码方式
        Encoding ASCII = Encoding.GetEncoding("gb2312");
        #endregion
        
        
        #region 内部函数
        // 将一行应答字符串记录在strReply和strMsg
        // 应答码记录在iReplyCode
        private void ReadReply()
        {
            strMsg = "";
            strReply = ReadLine();
            iReplyCode = Int32.Parse(strReply.Substring(0, 3));
        } 
 
        // 建立进行数据连接的socket
        private Socket CreateDSocket()
        {
            SendCommand("PASV");//请求服务器数据连接
            if (iReplyCode != 227)//227 若非进入被动模式
            {
                throw new IOException(strReply.Substring(4));
            }
            int index1 = strReply.IndexOf('(');
            int index2 = strReply.IndexOf(')');
            string ipDa =
             strReply.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];
            int len = ipDa.Length;
            int partCount = 0;
            string buf = "";
            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = Char.Parse(ipDa.Substring(i, 1));
                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                {
                    throw new IOException("Malformed PASV strReply: " + strReply);
                }
                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = "";
                    }
                    catch (Exception)
                    {
                        throw new IOException("Malformed PASV strReply: " + strReply);
                    }
                }
            }
            string ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];//ip地址段
            int port = (parts[4] << 8) + parts[5];
            Socket so = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endp = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            try
            {
                so.Connect(endp);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect to remote server");
            }
            return so;
        }

        // 关闭socket连接(用于登录以前)
        private void CloseSocketConnect()
        {
            if (socketControl != null)
            {
                socketControl.Close();
                socketControl = null;
            }
            bConnected = false;
        }

        // 读取Socket返回的所有字符串
        private string ReadLine()
        {
            while (true)
            {
                int iBytes = socketControl.Receive(buffer, buffer.Length, 0);
                strMsg += ASCII.GetString(buffer, 0, iBytes);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            char[] seperator = { '\n' };
            string[] message = strMsg.Split(seperator);
            if (message.Length > 2)
            {
                strMsg = message[message.Length - 2];
            }
            else
            {
                strMsg = message[0];
            }
            if (!strMsg.Substring(3, 1).Equals(" "))
            {
                return ReadLine();
            }
            return strMsg;
        }

        // 发送命令并获取应答码和最后一行应答字符串
        public void SendCommand(String strCommand)
        {
            Byte[] cmdBytes = Encoding.UTF8.GetBytes((strCommand + "\r\n").ToCharArray());
            socketControl.Send(cmdBytes, cmdBytes.Length, 0);
            ReadReply();
        }
        #endregion
    }


}
