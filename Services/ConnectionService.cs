using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector.Services
{
    class ConnectionService : IConnectionService
    {
        private int _timeout=500;

        public Socket Connect(string ip, int port)
        {
            IPAddress _ip;
            if (IPAddress.TryParse(ip, out _ip) == false)
            {
                IPHostEntry hst = Dns.GetHostEntry(ip);
                ip = hst.AddressList[0].ToString();
            }
            var tcpAsyCl = new Socket(IPAddress.Parse(ip).AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            tcpAsyCl.Connect(new IPEndPoint(_ip, port));
            tcpAsyCl.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _timeout);
            tcpAsyCl.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
            tcpAsyCl.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);
            return tcpAsyCl;
        }
    }
}
