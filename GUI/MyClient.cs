using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//--------------------
using System.Net;
using System.Net.Sockets;

namespace GUI
{
    class MyClient
    {
        public static List<Socket> ListClient = new List<Socket>();

        public void Add(Socket Soc)
        {
            ListClient.Add(Soc);
        }
        public void Delete(Socket soc)
        {
            ListClient.Remove(soc);
        }

        public Socket[] GetListAll()
        {
            return ListClient.ToArray();
        }

        public void SendMsg(IPEndPoint Ipe, string Msg)
        {
            foreach (Socket S in ListClient)
            {
                IPEndPoint IpEpoint = S.RemoteEndPoint as IPEndPoint;
                if (Ipe.Address.ToString() == IpEpoint.Address.ToString() && IpEpoint.Port == Ipe.Port)
                {
                    byte[] b = Encoding.Unicode.GetBytes(Msg);
                    S.Send(b);

                }


            }
        }


    }
}
