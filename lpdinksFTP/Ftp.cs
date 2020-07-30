using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace lpdinksFTP
{
    public class Ftp
    {
        private Socket cmdSocket;
        private static int getPort(byte[] receive, int n)
        {
            int port = 0;
            int p1 = 0;
            int p2 = 0;
            bool np1 = true;
            bool np2 = true;
            for (int i = n; i > 0; i--)
            {
                if (receive[i] == 41 && np2)
                {
                    np2 = false;
                    int muti = 0;//倍数
                    int k = i;
                    while (receive[k - 1] != 44)
                    {
                        p2 += (receive[k - 1] - 48) * Convert.ToInt32(Math.Pow(10, muti));
                        muti += 1;
                        k--;
                    }
                }

                if (receive[i] == 44 && np1)
                {
                    np1 = false;
                    int muti = 0;
                    int k = i;
                    while (receive[k - 1] != 44)
                    {
                        p1 += (receive[k - 1] - 48) * Convert.ToInt32(Math.Pow(10, muti));
                        muti += 1;
                        k--;
                    }
                }

                if (!np1 && !np2) break;
            }
            port = p1 * 256 + p2;
            return port;
        }
        private static Socket createSocket(string server, int port)
        {
            Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipa = IPAddress.Parse(server);
            IPEndPoint ipe = new IPEndPoint(ipa, port);
            s.Connect(ipe);
            return s;

        }

        public string signIn(string ip, string username, string password)
        {
            byte[] receive = new byte[64];
            string log = "";
            int port = 21;
            int size = 0;

            cmdSocket = createSocket(ip, port);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0","")+"\n";
            string cmdData;
            byte[] szData;

            cmdData = "USER " + username + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";

            cmdData = "PASS " + password + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";

            return log;

        }

        public string signOut()
        {
            string cmdData;
            string log="";
            byte[] szData;
            byte[] receive = new byte[64];
            int size;
            cmdData = "QUIT" + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";
            cmdSocket.Close();
            return log;
        }
        public string downLoadDuanDian(string IP,string url)
        {
            string cmdData;
            string log = "";
            byte[] szData;
            byte[] receive = new byte[1024];
            try
            {
                FileStream fs = new FileStream(url, FileMode.Open);
                int efileSize =Convert.ToInt32(fs.Length);

                cmdData = "PASV" + "\r\n";
                szData = Encoding.ASCII.GetBytes(cmdData);
                cmdSocket.Send(szData);
                int size = cmdSocket.Receive(receive);
                log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";


                int myport = getPort(receive, size);
                Socket datasocket = createSocket(IP, myport);

                cmdData = "SIZE " + url + "\r\n";
                szData = Encoding.ASCII.GetBytes(cmdData);
                cmdSocket.Send(szData);
                cmdSocket.Receive(receive);
                int i = 4;
                string consize = "";
                while (receive[i] != 13)
                {
                    consize += (receive[i] - 48);
                    i++;
                }
                //if (Convert.ToInt32(consize) == fs.Length) return "该文件已经下载完成";
                cmdData = "REST " + Convert.ToString(efileSize) + "\r\n";
                szData = Encoding.ASCII.GetBytes(cmdData);
                cmdSocket.Send(szData);
                cmdSocket.Receive(receive);
                log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";

                cmdData = "RETR " + url + "\r\n";
                szData = Encoding.ASCII.GetBytes(cmdData);
                cmdSocket.Send(szData);
                size = cmdSocket.Receive(receive);
                string temp = Encoding.UTF8.GetString(receive);
                if (receive[0] == 53 || receive[0] == 52) { MessageBox.Show("请求的文件不存在,或连接超时"); log += "下载失败\r\n"; return null; }


                //FileStream fileStreamData = new FileStream(url, FileMode.OpenOrCreate);
                byte[] receiveData = new byte[Convert.ToInt32(consize)];
                int datasize = datasocket.Receive(receiveData);
                fs.Write(receiveData, efileSize, Convert.ToInt32(consize));
                fs.Close();
                datasocket.Close();
                size = cmdSocket.Receive(receive);
                log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";
                log += "下载完毕\r\n";
                return log;

            }
            catch
            {
                return downLoad(IP, url);
            }
        }

        public string downLoad(string IP,string url)
        {
            string cmdData;
            string log = "";
            byte[] szData;
            byte[] receive = new byte[1024];
            int size;
            
            cmdData = "PASV" + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";
            

            int myport = getPort(receive, size);
            Socket datasocket = createSocket(IP, myport);
            
            cmdData = "SIZE " +url+ "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            cmdSocket.Receive(receive);
            int i = 4;
            string consize = "";
            while (receive[i] != 13)
            {
                consize += (receive[i] - 48);
                i++;
            }
            
            cmdData = "RETR "+url + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            string temp = Encoding.UTF8.GetString(receive);
            if (receive[0] == 53||receive[0]==52) { MessageBox.Show("请求的文件不存在,或连接超时");log += "下载失败\r\n"; return null; }


            FileStream fileStreamData = new FileStream(url, FileMode.OpenOrCreate);
            byte[] receiveData = new byte[Convert.ToInt32(consize)];
            int datasize = datasocket.Receive(receiveData);
            fileStreamData.Write(receiveData, 0, Convert.ToInt32(consize));
            fileStreamData.Close();
            datasocket.Close();
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\n";
            log += "下载完毕\r\n";
            return log;
        }
        public string upLoad(string IP,string url)
        {
            string cmdData;
            string log = "";
            byte[] szData;
            byte[] receive = new byte[64];
            int size;
            //上传文件
            cmdData = "PASV" + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\r\n";
            //for (int i = 0; i < size; i++) Console.WriteLine(receive[i]);
            int upport = getPort(receive, size);
            Socket datasocketup = createSocket(IP, upport);
            FileStream fsup = new FileStream(url, FileMode.Open);
            byte[] upData = new byte[fsup.Length];
            fsup.Read(upData,0,Convert.ToInt32(fsup.Length));
            fsup.Close();
            cmdData = "STOR "+ url.Substring(url.LastIndexOf("\\") + 1) + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\r\n";

            datasocketup.Send(upData);
            datasocketup.Close();
            if (receive[0] == 49)
            {
                size = cmdSocket.Receive(receive);
                log += Encoding.UTF8.GetString(receive).Replace("\0", "") + "\r\n";
                log += "上传成功\r\n";
            }
            else if (receive[0] == 53)
            {
                log += "上传失败\r\n";
            }
            return log;
        }
        public string getSize(string url)
        {
            string cmdData;
            byte[] szData;
            byte[] receive = new byte[64];
            string size = "";
            /*
            cmdData = "PASV" + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            cmdSocket.Receive(receive);
            */

            cmdData = "SIZE "+url + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            cmdSocket.Receive(receive);
            int i = 4;
            int muti = 0;
            while (receive[i] != 13)
            {
                size += (receive[i]-48);
                i++;
            }
            //size =Convert.ToInt32(Encoding.Default.GetString(receive));
            //fileStream.Write(receive, 0, size);
            return size;
        }
        private string getRev(string str)
        {

            char[] cs = str.ToCharArray();
            Array.Reverse(cs);

            string res = new string(cs);

            //Console.WriteLine(res);
            return res;
        }
        
        public List<DataBinding> getFileList(string IP)
        {
            string cmdData;
            byte[] szData;
            byte[] receive = new byte[64];
            int size;
            List<DataBinding> fileList = new List<DataBinding>();

            cmdData = "PASV" + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            int dataPort= getPort(receive, size);
            Socket datasocket = createSocket(IP, dataPort);


            cmdData = "LIST " + "\r\n";
            szData = Encoding.ASCII.GetBytes(cmdData);
            cmdSocket.Send(szData);
            size = cmdSocket.Receive(receive);
            string tmp = Encoding.UTF8.GetString(receive);
            byte[] receiveData = new byte[10240];
            int datasize = datasocket.Receive(receiveData);
            datasocket.Close();
            size = cmdSocket.Receive(receive);
            tmp = Encoding.UTF8.GetString(receive);
            Console.WriteLine(Encoding.UTF8.GetString(receiveData));
            
            for (int i = 0; i < 10240; i++)
            {
                string thisChar = "";
                if (receiveData[i] == 13)
                {
                    for(int k = i; k> 0; k--) {
                        if (receiveData[k] != 32)
                        {
                            thisChar += (char)receiveData[k];
                        }
                        else { break; }
                    }
                    DataBinding db = new DataBinding();
                    db.content = getRev(thisChar);
                    db.size = getSize(getRev(thisChar).Replace("\r",""));
                    fileList.Add(db);

                }
            }
            return fileList;



        }
    }
}
