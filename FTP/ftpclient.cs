using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    class ftpclient
    {
        public bool conneted = false;
        public bool logged = false;
        string hname;
        Socket socket = null;
        Socket dscoket = null;
        byte[] bytes = new byte[1000000000];
        public ftpclient(){};

        //连接方法
        public void connect(Socket hname,int p)
        {

        }

        //信息发送
        public string sendmsg(string message)
        {
            byte msg = Encoding.ASCII.GetBytes(message);
            socket.Send(msg);
            string rmsg = GetResponse(socket);
            return rmsg;
        }

        public void pmode() 
        {

        }

        public void disconnect()
        {

        }

        public List<String> Glist()
        {

        }

        public string CD()
        {

        }

        public void DownlFile()
        {

        }

        public void upFile()
        {

        }

        public string GetResponse(Socket socket)
        {

        }

        public byte[] GetReByte(Socket socket)
        {

        }

        public byte[] GetreByte(Socket socket,int size)
        {

        }

        public void RFile()
        {

        }

        public bool RS(String response)
        {

        }

    }
}
