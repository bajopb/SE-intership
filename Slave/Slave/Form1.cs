using Microsoft.VisualBasic;
using NModbus;
using NModbus.Data;
using NModbus.Device;
using Slave.Connection;
using Slave.Factory;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slave
{
    public partial class Form1 : Form
    {
        private readonly IConnection _connection;
        private TcpListener _listener;
        private TcpClient _client;
        private ISlaveFactory _factory;
        private IModbusSlaveNetwork _network;
        private IModbusSlave _slave;
        private SlaveDataStore _slaveDataStore;

        public event EventHandler<PointEventArgs> AfterWrite;

        public Form1()
        {
            InitializeComponent();
            _connection = new Connection.Connection();
            _factory = new SlaveFactory();
            _slaveDataStore = new SlaveDataStore();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client?.Close();
            _listener?.Stop();
        }


        private async Task Listening()
        {
            try
            {
                await _network.ListenAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateRTB(string opetaion)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => UpdateRTB(opetaion)));
                return;
            }
            rtbInfo.Text += opetaion + "\n";
        }

        private async Task SetNetwork() {
            _listener = await _connection.Connect();
            _client = await _listener.AcceptTcpClientAsync();
            _network = _factory.CreateSlaveNetwork(_listener);
            _slaveDataStore.CoilDiscretes.AfterWrite += (sender, args) => UpdateRTB("Coils: Write on Address: " + args.StartAddress + ", Number of Points: " + args.NumberOfPoints);
            _slaveDataStore.HoldingRegisters.AfterWrite += (sender, args) => UpdateRTB("Holding Rgisters: Write on Address " + args.StartAddress + ", Number of Points: " + args.NumberOfPoints);
            _slaveDataStore.CoilInputs.BeforeRead += (sender, args) => UpdateRTB("Discrete Inputs: Read on Address " + args.StartAddress + ", Number of Points: " + args.NumberOfPoints);
            _slaveDataStore.InputRegisters.BeforeRead += (sender, args) => UpdateRTB("Input Registers: Read on Address " + args.StartAddress + ", Number of Points: " + args.NumberOfPoints);
            _slave = _factory.CreateSlave(_slaveDataStore);
            _network.AddSlave(_slave);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await SetNetwork();
            await Listening();
        }


    }
}
