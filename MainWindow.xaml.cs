using ModBus_connector.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModBus_connector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] tcpSynClBuffer = new byte[2048];

        public MainWindow()
        {
            InitializeComponent();
            ConnectionService connectionService = new();
            var x = connectionService.Connect("127.0.0.1",502);
            x.Send(new byte[12]{ 0,2,0,0,0,6,1,2,0,0,0,1}, 0, 12, SocketFlags.None);
            int result = x.Receive(tcpSynClBuffer, 0, tcpSynClBuffer.Length, SocketFlags.None);

        }
    }
}
