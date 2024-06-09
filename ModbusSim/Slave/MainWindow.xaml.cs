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
        private TcpListener _tcpListener;
        IModbusFactory factory;
        IModbusSlave slave;
        ISlaveDataStore slaveDataStore;
        IModbusSlaveNetwork slaveNetwork;
        public MainWindow()
        {
            InitializeComponent();
            _connectionService = new ConnectionService();
            factory=new ModbusFactory();
            slaveDataStore=new SlaveDataStore();
        }

        private async Task Listening()
        {
            try
            {
                await slaveNetwork.ListenAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {


            _tcpListener = await _connectionService.Connect();
            TcpClient handler = await _tcpListener.AcceptTcpClientAsync();
            createslave();
            await Listening();

        }

        private void createslave() {
            slave = factory.CreateSlave(1, slaveDataStore);
            slave.DataStore.CoilDiscretes.WritePoints(1, new bool[] { true, false, true });
            slave.DataStore.CoilInputs.WritePoints(10001, new bool[] { true, false, true });
            slave.DataStore.InputRegisters.WritePoints(30001, new ushort[] { 100, 1000, 10000 });
            slave.DataStore.HoldingRegisters.WritePoints(40001, new ushort[] { 100, 1000, 10000 });
            slaveNetwork = factory.CreateSlaveNetwork(_tcpListener);
            slaveNetwork.AddSlave(slave);
        }

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            finally
            {
                //_tcpListener.Stop();
            }
        }

        private async void btnConnect_Copy_Click(object sender, RoutedEventArgs e)
        {
            


        }
    }
}
