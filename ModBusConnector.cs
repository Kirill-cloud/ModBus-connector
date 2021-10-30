using ModBus_connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector
{
    public class ModBusConnector
    {
        private IConnectionService connectionService;
        private string ip = "127.0.0.1";

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int port = 502;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private byte[] tcpSynClBuffer = new byte[2048];

        public ModBusConnector(IConnectionService connectionService)
        {
            this.connectionService = connectionService;
        }

        public bool GetValue()
        {
            var socket = connectionService.Connect(Ip, Port);
            socket.Send(new byte[12] { 0, 2, 0, 0, 0, 6, 1, 2, 0, 0, 0, 1 }, 0, 12, SocketFlags.None);
            int result = socket.Receive(tcpSynClBuffer, 0, tcpSynClBuffer.Length, SocketFlags.None);
            return true;
        }
    }
}
