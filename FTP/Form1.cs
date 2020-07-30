using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using System.Net.Sockets;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FTP
{
    public partial class Form1 : Form
    {
        private FtpClient ftp_client;
        private string path;        // 本地路径
        public List<String> localList = null;
        public List<FileInfomation> files = null;
        public int BP = 0;

        public Form1()
        {
            InitializeComponent();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinEngine1.SkinFile = Application.StartupPath + "//mp10.ssk";

            // var materialSkinManager = MaterialSkinManager.Instance;
            // materialSkinManager.AddFormToManage(this);
            // materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);

            localListBox.DrawItem += LocalListBox_DrawItem;
            fileList.DrawItem += FileList_DrawItem;
        }

        #region 文件列表区域绘图
        private void FileList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush myBrush = Brushes.Black;
            Color RowBackColorSel = Color.FromArgb(150, 200, 250);//选择项目颜色
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = new SolidBrush(RowBackColorSel);
            }
            else
            {
                myBrush = new SolidBrush(Color.White);
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);
            e.DrawFocusRectangle();//焦点框

            //绘制图标
            Image image = imageListFileFolder.Images[files[e.Index].IsFolder ? 0 : 1];
            Graphics graphics = e.Graphics;
            Rectangle bound = e.Bounds;
            Rectangle imgRec = new Rectangle(
                bound.X,
                bound.Y,
                bound.Height,
                bound.Height);
            Rectangle textRec = new Rectangle(
                imgRec.Right,
                bound.Y,
                bound.Width - imgRec.Right,
                bound.Height);
            if (image != null)
            {
                e.Graphics.DrawImage(
                    image,
                    imgRec,
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel);
                //绘制字体
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(fileList.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), textRec, stringFormat);
            }
        }
        

        private void LocalListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //throw new NotImplementedException();
            Brush myBrush = Brushes.Black;
            Color RowBackColorSel = Color.FromArgb(150, 200, 250);//选择项目颜色
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = new SolidBrush(RowBackColorSel);
            }
            else
            {
                myBrush = new SolidBrush(Color.White);
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);
            e.DrawFocusRectangle();//焦点框

            //绘制图标
            Image image = imageListFileFolder.Images[localList[e.Index][0] == 'f' ? 1: 0];
            Graphics graphics = e.Graphics;
            Rectangle bound = e.Bounds;
            Rectangle imgRec = new Rectangle(
                bound.X,
                bound.Y,
                bound.Height,
                bound.Height);
            Rectangle textRec = new Rectangle(
                imgRec.Right,
                bound.Y,
                bound.Width - imgRec.Right,
                bound.Height);
            if (image != null)
            {
                e.Graphics.DrawImage(
                    image,
                    imgRec,
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel);
                //绘制字体
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(localListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), textRec, stringFormat);
            }
        }
        #endregion


        #region 连接/断开连接操作
        //连接
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            localList = new List<string>();
            files = new List<FileInfomation>();
            string userName = this.usernameBox.Text;
            string userPasw = this.passwordBox.Text;
            //string hostName = this.hostNameBox.Text;
            string hostIP = this.hostNameBox.Text;
            path = @"D:\Client";
            ftp_client = new FtpClient(hostIP, "", userName, userPasw, 21);

            // 获取远程服务器文件列表
            GetRemoteList();

            //获取本地文件列表
            GetLocalList();
            
        }
        //断开连接
        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            ftp_client.DisConnect();
            //页面有关元素清除
            this.localListBox.DataSource = null;
            this.fileList.Items.Clear();
            this.label9.Text = "未连接";
            this.usernameBox.Text = "";
            this.passwordBox.Text = "";
            //
        }
        #endregion


        #region 服务器端操作
        //服务器下载
        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            double count=0;
            if (ftp_client.flag == false) label8.Text = "开始下载";
            try
            {
                if (fileList.SelectedIndex != -1)
                {
                    
                    ftp_client.Download(files[fileList.SelectedIndex].FileName, path, files[fileList.SelectedIndex].FileName, BP);
                    ///backgroundWorker1.RunWorkerAsync(10);
                    while (count < 100)
                    {
                        count = count + 0.1;
                        if (BP == 0) label8.Text = "下载完成";
                    }
                    if (BP == 0) label8.Text = "下载完成";
                    GetLocalList();
                }
                else { MessageBox.Show("请选择需要下载的文件！"); }
            }
            catch (Exception ex)
            {
                // 下载失败！
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //服务器 路径返回
        private void ButtonBackDown_Click(object sender, EventArgs e)
        {
            ftp_client.SendCommand("CDUP\r\n");
            GetRemoteList();
        }

        //服务器 路径进入
        private void ButtonEnterDown_Click(object sender, EventArgs e)
        {
            String folderName = files[fileList.SelectedIndex].FileName;
            try
            {
                ftp_client.ChDir(folderName);
                GetRemoteList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //服务器删除文件
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //文件夹：
            if (files[fileList.SelectedIndex].IsFolder)
            {
                try
                {
                    ftp_client.RmDir(files[fileList.SelectedIndex].FileName);
                }
                catch
                {
                    MessageBox.Show("目标文件夹非空！");
                }
            }
            //文件
            else
            {
                ftp_client.Delete(files[fileList.SelectedIndex].FileName);
            }
            GetRemoteList();
        }

        //服务器 文件重命名
        private void ButtonRename_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileList.SelectedIndex != -1)
                {
                    ftp_client.Rename(files[fileList.SelectedIndex].FileName, renameText.Text);
                    GetRemoteList();
                }
                else
                {
                    MessageBox.Show("请选择需要更改名称的文件！");
                }
            }
            catch
            {
                MessageBox.Show("修改失败，请检查是否有重名文件！");
            }
        }
        //服务器 创建新文件夹
        private void ButtonBuildNew_Click(object sender, EventArgs e)
        {
            //string str = Interaction.InputBox("请输入文件夹名", "文件夹", "", 100, 100)
            //TODO: 后面要提示，自己输入新建文件夹名称，这里预设为“新建文件夹”
            try
            {
                ftp_client.MkDir("NewFolder");
                GetRemoteList();
            }
            catch
            {
                MessageBox.Show("文件命名冲突，请检查是否有重名文件");
            }
            //GetRemoteList();
        }

        //
        private void ButtonStopUp_Click(object sender, EventArgs e)
        {

        }
        //选取文件发生变化
        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (files[fileList.SelectedIndex].IsFolder) { this.label9.Text = "选中了1个文件夹 " + files[fileList.SelectedIndex].FileName; }
            else { this.label9.Text = "选中了文件" + files[fileList.SelectedIndex].FileName + ", 大小总计为" + files[fileList.SelectedIndex].Size.ToString() + " KB"; }

        }
        #endregion


        #region 本地操作
        //本地 路径返回
        private void ButtonBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != @"D:\")
                {
                    path = path.Substring(0, path.LastIndexOf('\\'));
                    if (path == "D:")
                    {
                        path = @"D:\";
                    }
                    GetLocalList();
                }
            }
            catch
            {
                MessageBox.Show("Error occured!");
            }
        }
        //本地 路径进入
        private void ButtonEnterUp_Click(object sender, EventArgs e)
        {
            try
            {
                path = localList[localListBox.SelectedIndex].Substring(1);
                GetLocalList();
            }

            catch
            {
                MessageBox.Show("Error occured!");
            }
        }
        //停止下载
        private void ButtonStopDown_Click(object sender, EventArgs e)
        {
            if (ftp_client.flag == false)
            {
                ftp_client.flag = !ftp_client.flag;
                label8.Text = "已暂停（断点设置）";
            }
            
            else if(ftp_client.flag == true) label8.Text = "继续下载";

            GetLocalList();
        }
        //本地上传文件
        private void uploadButton_Click(object sender, EventArgs e)
        {
            double count = 0;
            try
            {
                if (localListBox.SelectedIndex != -1)
                {
                    ftp_client.Upload(localList[localListBox.SelectedIndex].Substring(1), path);
                    while (count < 100)
                    {
                        count = count + 0.1;
                        if (BP == 0) label8.Text = "下载完成";
                    }
                    if (BP == 0) label8.Text = "下载完成";
                    GetRemoteList();
                }
                else { MessageBox.Show("请选择要上传的文件！"); }
            }
            catch (Exception ex)
            {
                //上传失败，不能上传文件夹
                MessageBox.Show(ex.Message.ToString());
            }
        }
        // 回到home dir
        private void ButtonHome_Click(object sender, EventArgs e)
        {
            path = @"D:";
            GetLocalList();
        }
        #endregion


        #region 路径更新操作
        //获取服务器路径
        public void GetRemoteList()
        {
            fileList.DrawMode = DrawMode.OwnerDrawFixed;
            string[] tmp = ftp_client.getlist("");
            this.fileList.Items.Clear();
            files.Clear();
            FileInfomation File;
            // 临时文件夹
            List<FileInfomation> TmpFolder = new List<FileInfomation>();
            // 临时文件
            List<FileInfomation> TmpFile = new List<FileInfomation>();
            for (int i = 0; i < tmp.Length; i++)
            {
                // Console.WriteLine(tmp[i].ToString());
                File = new FileInfomation(tmp[i].ToString());
                if (File.IsFolder) { TmpFolder.Add(File); }
                else { TmpFile.Add(File); }
            }
            //添加文件夹
            string fileLength;
            for(int i = 0; i < TmpFolder.Count; i++)
            {
                this.fileList.Items.Add(getSizeString(TmpFolder[i].FileName, 20) +" " +getSizeString(TmpFolder[i].ModifiedAt.ToString(), 16));
                files.Add(TmpFolder[i]);
            }
            for(int i = 0; i < TmpFile.Count; i++)
            {
                fileLength = TmpFile[i].Size.ToString() + " B";
                this.fileList.Items.Add(getSizeString(TmpFile[i].FileName, 20) + " " + getSizeString(TmpFile[i].ModifiedAt, 16) + " " + fileLength);
                files.Add(TmpFile[i]);
            }
            if(fileList.Items.Count > 0) { this.fileList.SelectedIndex = 0; }
        }

        //获取本地路径
        public void GetLocalList()
        {
            localListBox.DrawMode = DrawMode.OwnerDrawFixed;
            try
            {
                String[] localDirectories = Directory.GetDirectories(path);
                
                String[] localFiles = Directory.GetFiles(path);
                localList = new List<string>();
                List<String> dataSource = new List<string>();
                FileInfo TmpLocalFile;//  = new FileInfo();
                foreach (String s in localDirectories)
                {
                    TmpLocalFile = new FileInfo(s);
                    //文件夹在local List中标识， 第一个字母为d
                    localList.Add("d" + s);
                    dataSource.Add(getSizeString(TmpLocalFile.Name,20) + " " + getSizeString(TmpLocalFile.LastWriteTime.ToString(), 20));
                }

                foreach (String s in localFiles)
                {
                    TmpLocalFile = new FileInfo(s);
                    //文件在local List中标识， 第一个字母为f
                    localList.Add("f" + s);
                    dataSource.Add(getSizeString(TmpLocalFile.Name, 20) + " " + getSizeString(TmpLocalFile.LastWriteTime.ToString(), 20) + " " + TmpLocalFile.Length + " B");
                }

                pathBox.Text = path;

                localListBox.DataSource = null;
                localListBox.DataSource = dataSource;
                if(localListBox.Items.Count > 0) { this.localListBox.SelectedIndex = 0; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //对某字符串取固定位数的字串
        public string getSizeString(string s, int byteSize)
        {
            int sum = 0;
            string ans = "";
            for(int i = 0; i < s.Length; i++)
            {
                string mChar = s.Substring(i, 1);
                int byteCount = Encoding.Default.GetByteCount(mChar);//关键点判断字符所占的字节数
                if(byteCount == 1) { sum++; ans += mChar; }
                else { sum += 2; ans += mChar; }
                if(sum >= byteSize) { break; }
            }
            while(sum < byteSize)
            {
                ans += " "; sum++;
            }
            return ans;
        }
        #endregion

        
    }
}
