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
            ((SlaveDataStore)slave.DataStore).HoldingRegisters.AfterWrite += SetRegistersAfterWrite;
            ((SlaveDataStore)slave.DataStore).InputRegisters.AfterWrite += SetRegistersAfterWrite;
            factory.SlaveNetwork.AddSlave(slave);
            SetRegisters();
            await Listening();
        }
        #region Input registers seting
        private void tbSetIRGrindingMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if(ushort.TryParse(tbSetIRGrindingMethod.Text, out ushort method)){
                tbSetIRGrindingMethod.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30001, new ushort[] {method});
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRGrindingMethod.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRGrindingTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRGrindingTemperature.Text, out ushort temperature))
            {
                tbSetIRGrindingTemperature.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30002, new ushort[] { temperature });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRGrindingTemperature.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRGrindingTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRGrindingTime.Text, out ushort time))
            {
                tbSetIRGrindingTime.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30003, new ushort[] { time });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRGrindingTime.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRSaharificationMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRSaharificationMethod.Text, out ushort method))
            {
                tbSetIRSaharificationMethod.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30004, new ushort[] { method });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRSaharificationMethod.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRSaharificationTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRSaharificationTemperature.Text, out ushort temperature))
            {
                tbSetIRSaharificationTemperature.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30005, new ushort[] { temperature });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRSaharificationTemperature.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRSaharificationTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRSaharificationTime.Text, out ushort time))
            {
                tbSetIRSaharificationTime.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30006, new ushort[] { time });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRSaharificationTime.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRMashoutTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRMashoutTemperature.Text, out ushort temperature))
            {
                tbSetIRMashoutTemperature.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30007, new ushort[] { temperature });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRMashoutTemperature.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRMashoutTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRMashoutTime.Text, out ushort time))
            {
                tbSetIRMashoutTime.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30008, new ushort[] { time });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRMashoutTime.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRFilteringTemperature_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRFilteringTemperature.Text, out ushort temperature))
            {
                tbSetIRFilteringTemperature.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30009, new ushort[] { temperature });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRFilteringTemperature.BorderBrush = Brushes.Red;
            }
        }

        private void tbSetIRFilteringTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (ushort.TryParse(tbSetIRFilteringTime.Text, out ushort time))
            {
                tbSetIRFilteringTime.BorderBrush = Brushes.Black;
                slave.DataStore.InputRegisters.WritePoints(30010, new ushort[] { time });
            }
            else
            {
                MessageBox.Show("Enter valid value.");
                tbSetIRFilteringTime.BorderBrush = Brushes.Red;
            }
        }
        private void SetRegistersAfterWrite(object sender, EventArgs args)
        {
            Task.Run(async () =>
            {
                await SetRegisters();
            });
        }
        private async Task SetRegisters()
        {
            await Task.Delay(1000);

            Application.Current.Dispatcher.Invoke(() =>
            {
                tbGrinderMethod.Text = slave.DataStore.HoldingRegisters.ReadPoints(40001, 1)[0].ToString();
                tbGrinderTemperature.Text = slave.DataStore.HoldingRegisters.ReadPoints(40002, 1)[0].ToString();
                tbGrinderTime.Text = slave.DataStore.HoldingRegisters.ReadPoints(40003, 1)[0].ToString();
                tbSaharificationMethod.Text = slave.DataStore.HoldingRegisters.ReadPoints(40004, 1)[0].ToString();
                tbSaharificationTemperature.Text = slave.DataStore.HoldingRegisters.ReadPoints(40005, 1)[0].ToString();
                tbSaharificationTime.Text = slave.DataStore.HoldingRegisters.ReadPoints(40006, 1)[0].ToString();
                tbMashoutTemperature.Text = slave.DataStore.HoldingRegisters.ReadPoints(40007, 1)[0].ToString();
                tbMashoutTime.Text = slave.DataStore.HoldingRegisters.ReadPoints(40008, 1)[0].ToString();
                tbFilteringTemperature.Text = slave.DataStore.HoldingRegisters.ReadPoints(40009, 1)[0].ToString();
                tbFilteringTime.Text = slave.DataStore.HoldingRegisters.ReadPoints(40010, 1)[0].ToString();

                tbSetIRGrindingMethod.Text = slave.DataStore.InputRegisters.ReadPoints(30001, 1)[0].ToString();
                tbSetIRGrindingTemperature.Text = slave.DataStore.InputRegisters.ReadPoints(30002, 1)[0].ToString();
                tbSetIRGrindingTime.Text = slave.DataStore.InputRegisters.ReadPoints(30003, 1)[0].ToString();
                tbSetIRSaharificationMethod.Text = slave.DataStore.InputRegisters.ReadPoints(30004, 1)[0].ToString();
                tbSetIRSaharificationTemperature.Text = slave.DataStore.InputRegisters.ReadPoints(30005, 1)[0].ToString();
                tbSetIRSaharificationTime.Text = slave.DataStore.InputRegisters.ReadPoints(30006, 1)[0].ToString();
                tbSetIRMashoutTemperature.Text = slave.DataStore.InputRegisters.ReadPoints(30007, 1)[0].ToString();
                tbSetIRMashoutTime.Text = slave.DataStore.InputRegisters.ReadPoints(30008, 1)[0].ToString();
                tbSetIRFilteringTemperature.Text = slave.DataStore.InputRegisters.ReadPoints(30009, 1)[0].ToString();
                tbSetIRFilteringTime.Text = slave.DataStore.InputRegisters.ReadPoints(30010, 1)[0].ToString();
            });
        }

        #endregion
    }
}
