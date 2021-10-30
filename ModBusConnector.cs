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
        private byte[] readInputsCommand = new byte[12] { 0, 2, 0, 0, 0, 6, 1, 2, 0, 0, 0, 1 };
        private byte[] tcpSynClBuffer = new byte[2048];

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
        
        public ModBusConnector(IConnectionService connectionService)
        {
            this.connectionService = connectionService;
        }

        public bool GetValue()
        {
            var socket = connectionService.Connect(Ip, Port);
            socket.Send(readInputsCommand, 0, readInputsCommand.Length, SocketFlags.None);
            int result = socket.Receive(tcpSynClBuffer, 0, tcpSynClBuffer.Length, SocketFlags.None);
            
            var data = new byte[tcpSynClBuffer[8]];
            Array.Copy(tcpSynClBuffer, 9, data, 0, tcpSynClBuffer[8]);
            return Convert.ToBoolean(data[0]);
        }
    }
}
