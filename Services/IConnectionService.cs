using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModBus_connector.Services
{
    public interface IConnectionService
    {
        public Socket Connect(string ip, int port);
    }
}
