using Master.Connection;
using Master.Factory;
using NModbus;
using NModbus.Device;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Master
{
    public partial class Form1 : Form
    {
        private readonly IConnection _connection;
        private IModbusMaster _master;

        public Form1()
        {
            InitializeComponent();
            _connection = new Connection.Connection();
        }

        //private async void btnCheckConnection_Click(object sender, EventArgs e)
        //{
        //    await StartCommunication();
        //}

        //private async Task StartCommunication()
        //{
        //    var buffer = new byte[1_024];
        //    if (_client.Connected)
        //    {
        //        try
        //        {

        //            NetworkStream stream = _client.GetStream();
        //            int received = await stream.ReadAsync(buffer, 0, buffer.Length);

        //            if (received == 0)
        //            {
        //                MessageBox.Show("Connection closed by remote host");
        //            }

        //            var message = Encoding.UTF8.GetString(buffer, 0, received);
        //            MessageBox.Show($"Message received: \"{message}\"");

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //}

        private async Task SetMaster()
        {
            _master = await _connection.Connect();
        }
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            await SetMaster();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connection.Disconnect();
        }

        private async void btnReadCoils_Click(object sender, EventArgs e)
        {
            rtbResponse.Text = string.Empty;
            FormInput form = new FormInput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                bool[] coils = await _master.ReadCoilsAsync(1, form.StartAddress, form.NumberOfPoints);
                for (int i = 0; i < coils.Length; i++)
                {
                    rtbResponse.Text += "Coil " + i + ": " + coils[i].ToString() + "\n";
                }
            }
            form.Dispose();
        }

        private async void btnReadDI_Click(object sender, EventArgs e)
        {
            rtbResponse.Text = string.Empty;
            FormInput form = new FormInput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                bool[] dis = await _master.ReadInputsAsync(1, form.StartAddress, form.NumberOfPoints);
                for (int i = 0; i < dis.Length; i++)
                {
                    rtbResponse.Text += "Discrete Input " + i + ": " + dis[i].ToString() + "\n";
                }
            }
            form.Dispose();
        }



        private async void btnReadIR_Click(object sender, EventArgs e)
        {
            rtbResponse.Text = string.Empty;
            FormInput form = new FormInput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ushort[] dis = await _master.ReadInputRegistersAsync(1, form.StartAddress, form.NumberOfPoints);
                for (int i = 0; i < dis.Length; i++)
                {
                    rtbResponse.Text += "Input Register " + i + ": " + dis[i].ToString() + "\n";
                }
            }
            form.Dispose();
        }

        private async void btnReadMultiHR_Click(object sender, EventArgs e)
        {
            rtbResponse.Text = string.Empty;
            FormInput form = new FormInput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                ushort[] dis = await _master.ReadHoldingRegistersAsync(1, form.StartAddress, form.NumberOfPoints);
                for (int i = 0; i < dis.Length; i++)
                {
                    rtbResponse.Text += "Holding Register " + i + ": " + dis[i].ToString() + "\n";
                }
            }
            form.Dispose();
        }

        private async void btnWriteMultiCoils_Click(object sender, EventArgs e)
        {
            FormWriteMultiHr form = new FormWriteMultiHr();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _master.WriteMultipleCoilsAsync(1, 1, form.Values);
            }
            form.Dispose();
        }

        private async void btnWriteSingleCoils_Click(object sender, EventArgs e)
        {
            ForrmWriteInput form = new ForrmWriteInput();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _master.WriteSingleCoilAsync(1, form.Address, form.Value);
            }
            form.Dispose();
        }

        private async void btnWriteSingleHR_Click(object sender, EventArgs e)
        {
            FormSingleHRWrite form = new FormSingleHRWrite();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _master.WriteSingleRegisterAsync(1, form.Address, form.Value);
            }
            form.Dispose();
        }
    }
}
