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
        bool needToShow;
        public MainWindow()
        {
            InitializeComponent();
            ModBusConnector connector = new(new ConnectionService());
            needToShow = connector.GetValue(); // выведи на экран, вызвать при кнопке обновить
        }

        private void refresher_Click(object sender, RoutedEventArgs e)
        {
            condition.Content = needToShow;
        }
    }
}
