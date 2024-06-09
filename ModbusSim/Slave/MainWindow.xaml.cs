using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
using Slave.Interfaces;
using Slave.Services;
using NModbus;
using NModbus.Data;
using NModbus.Device;

namespace Slave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConnectionService _connectionService;
        ISlaveFactory factory;
        IModbusSlave slave;
        public MainWindow()
        {
            InitializeComponent();
            _connectionService = new ConnectionService();
            factory=new SlaveFactoryService();
        }

        private async Task Listening()
        {
            try
            {
                await factory.SlaveNetwork.ListenAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            await _connectionService.Connect();
            await  _connectionService.Listener.AcceptTcpClientAsync();
            factory.CreateSlaveNetwork(_connectionService.Listener);
            slave = factory.CreateSlave();
            factory.SlaveNetwork.AddSlave(slave);
            await Listening();
        }
    }
}
