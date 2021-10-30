using ModBus_connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector
{
    public class ModBusConnector
    {
        private IConnectionService connectionService;
        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int port;

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
            connectionService.Connect(Ip, Port);
            return true;
        }
    }
}
