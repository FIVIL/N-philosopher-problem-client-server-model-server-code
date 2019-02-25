using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    public delegate void SetCondition(int Cond, int index);
    public delegate void SetStatus(string state, int index);
    class servant
    {
        Dictionary<string, int> ListAllClinet = new Dictionary<string, int>();
        List<string> allclinet = new List<string>();
        string ip;
        int port;
        int[] Phphilosopher = new int[5];
        int[] fork = new int[5];
        Random rnd = new Random();
        ////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 0 start
        /// 1 think
        /// 2 w8
        /// 3 eat
        /// </summary>
        /// <param name="Phphilosophercnd"></param>
        /// <param name="index"></param>
        public void set(int Phphilosophercnd, int index)
        {
            if (OnSetCondition != null && Phphilosopher[index] != Phphilosophercnd)
            {
                OnSetCondition(Phphilosopher[index], index);
                Phphilosopher[index] = Phphilosophercnd;
            }
        }
        //0 start
        //1 think
        //2 w8
        //3 eat

        public int get(int index)
        {
            return Phphilosopher[index];
        }
        public event SetCondition OnSetCondition;
        public event SetStatus OnSetStatus;

        //////////////////////////////////////////////////////////////////////////////////// 

        public servant(string ip, int port)
        {
            for (int i = 0; i < 5; i++)
            {
                fork[i] = -1;
                set(0, i);
            }
            this.ip = ip;
            this.port = port;
            Thread Tr = new Thread(StartServer);
            Tr.Start();
            Console.WriteLine("start");
        }
        private void StartServer()
        {
            bool check = true;
            Socket ServerSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSoc.Bind(new IPEndPoint(IPAddress.Parse(ip), (port)));
            ServerSoc.Listen(1);
            while (true)
            {
                if (ListAllClinet.Count == 5 && check)
                {
                    SendToAll("start");
                    check = false;
                }
                if (check)
                {
                    Socket ClientSoc = ServerSoc.Accept();
                    MyClient m = new MyClient();
                    m.Add(ClientSoc);
                    GetAllClientList();
                    Thread tr = new Thread(GetData);
                    tr.Start(ClientSoc);      
                }
            }
        }
        private void GetData(object ObJSoc)
        {
            Socket Soc = (Socket)ObJSoc;
            while (true)
            {
                byte[] b = new byte[1024];
                int r = Soc.Receive(b);
                IPEndPoint Ip = Soc.RemoteEndPoint as IPEndPoint;
                if (r > 0)
                {
                    string msg = (Encoding.Unicode.GetString(b, 0, r));
                    serve(msg, Ip);
                }
            }

        }
        private void GetAllClientList()
        {
            MyClient m = new MyClient();
            Socket[] msoc = m.GetListAll();
            ListAllClinet.Clear();
            allclinet.Clear();
            int index = 0;
            foreach (Socket s in msoc)
            {
                IPEndPoint Ip = s.RemoteEndPoint as IPEndPoint;
                ListAllClinet.Add(Ip.Address + ":" + Ip.Port, index);
                allclinet.Add(Ip.Address + ":" + Ip.Port);
                index++;
            }
            int a = rnd.Next(2500, 5000);
            int b = rnd.Next(2300, 4700);
            int c = rnd.Next(20, 30);
            string rands = "ran:" + a + ":" + b + ":" + c+":"+(index);
            SendToSpecificClient(rands,allclinet[index-1]);
            //Console.WriteLine(ListAllClinet[index-1]);
        }
        private void SendToAll(string mes)
        {
            MyClient m = new MyClient();
            Socket[] asoc = m.GetListAll();
            byte[] bmsg = new byte[1024];
            bmsg = Encoding.Unicode.GetBytes(mes);
            foreach (Socket s in asoc)
            {
                s.Send(bmsg);
            }
        }
        private void SendToSpecificClient(string mes, string Cname)
        {
            //Console.WriteLine(Cname + " " + mes);
            if (mes.Length >= 0)
            {
                string SelectItem = Cname;
                string Ip = SelectItem.Substring(0, SelectItem.IndexOf(":"));
                string Port = SelectItem.Substring(SelectItem.IndexOf(":") + 1, SelectItem.Length - SelectItem.IndexOf(":") - 1);
                IPEndPoint IpEpoint = new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port));
                MyClient m = new MyClient();
                m.SendMsg(IpEpoint, mes);
            }
        }
        private void serve(string msg, IPEndPoint ipe)
        {
            print(msg, ipe);
            if (msg.Contains("status:")) updatestatus(msg, ipe);
            if (msg.Contains("gave up")) PutForckOnTable(ipe);
            if (msg.Contains("request right")) GetRightFork(ipe);
            if (msg.Contains("request left")) GetLeftFork(ipe);
            if (msg.Contains("done")) PutBothForkOnTable(ipe);
        }
        private void updatestatus(string msg, IPEndPoint ipe)
        {
            if (OnSetStatus != null) OnSetStatus(msg, map(ipe));
            if (msg.Contains("waiting"))
            {
                set(2, map(ipe));
                SendToSpecificClient("w8", ipe.ToString());
            }
            if (msg.Contains("thinking"))
            {
                set(1, map(ipe));
                SendToSpecificClient("think", ipe.ToString());
            }
            if (msg.Contains("eating"))
            {
                set(3, map(ipe));
                SendToSpecificClient("eat", ipe.ToString());
            }
        }
        private int map(IPEndPoint ipe)
        {
            return ListAllClinet[ipe.ToString()];
        }
        private void PutForckOnTable(IPEndPoint ipe)
        {
            fork[map(ipe)] = -1;
            SendToSpecificClient("ok", ipe.ToString());
        }
        private void GetRightFork(IPEndPoint ipe)
        {
            if (fork[map(ipe)] == -1)
            {
                fork[map(ipe)] = map(ipe);
                SendToSpecificClient("permission granted", ipe.ToString());
            }
            else
            {
                SendToSpecificClient("permission denied", ipe.ToString());
            }
        }
        private void GetLeftFork(IPEndPoint ipe)
        {
            int help = (map(ipe) + 1);
            if (help > 4) help = 0;
            //Console.WriteLine(help);
            if (fork[help] == -1)
            {
                fork[help] = (help);
                SendToSpecificClient("permission granted", ipe.ToString());
            }
            else
            {
                SendToSpecificClient("permission denied", ipe.ToString());
            }
        }
        private void PutBothForkOnTable(IPEndPoint ipe)
        {
            int help = (map(ipe) + 1);
            if (help > 4) help = 0;
            //Console.WriteLine(help);
            fork[map(ipe)] = -1;
            fork[help] = -1;
            SendToSpecificClient("ok", ipe.ToString());
        }
        private void print(string msg, IPEndPoint ipe)
        {
            //Console.WriteLine(map(ipe) + " " + msg);
        }
    }
}
