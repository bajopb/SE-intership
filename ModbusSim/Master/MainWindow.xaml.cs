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
using Master.Interfaces;
using Master.Services;
using NModbus;
using NModbus.Device;
using NModbus.Message;
using System.Diagnostics.Metrics;
using Master.Views;
using Master.Models;
using Master.Views.DevicesViews;
using System.Runtime.CompilerServices;
using Master.Views.Events;

namespace Master
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IConnectionService _connectionService;
        IMasteraFactoryService _factory;
        Device device1;
        public MainWindow()
        {
            InitializeComponent();
            _connectionService=new ConnectionService();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client==null || !_connectionService.Client.Connected)
            {
                    
                await _connectionService.Connect();
                await _connectionService.Connect();
                _factory = new MasterFactoryService(_connectionService.Client);
                _factory.CreateMaster();
                device1 = new Device(_factory, 1, "127.0.0.1", 13);
                device1.SetRegistersForGrinding(1,1,2,2,3,3);
                device1.SetRegistersForSaharification(4,4,5,5,6,6);
                device1.SetRegistersForMashout(7,7,8,8);
                device1.SetRegistersForFiltering(9,9,10,10);
                btnConnect.Content = "Disconnect";
            }
            else
            {
                _connectionService.Disconect();
                btnConnect.Content = "Connect";

            }
        }

        private async void btnReadCoils_Click(object sender, RoutedEventArgs e)
        {
            if(_connectionService.Client==null || _factory.Master==null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            ReadCoilsView form=new ReadCoilsView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    bool[] coils = await _factory.ReadCoils(form.UnitId, form.StartAddress, form.NumberOfPoints);
                    if (coils != null)
                    {
                        for (int i = 0; i < coils.Length; i++)
                        {
                            tbInfo.Text += "\n" + coils[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnReadDiscreteInputs_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            ReadCoilsView form = new ReadCoilsView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    bool[] dis = await _factory.ReadDiscreteInputs(form.UnitId, form.StartAddress, form.NumberOfPoints);
                    if (dis != null)
                    {
                        for (int i = 0; i < dis.Length; i++)
                        {
                            tbInfo.Text += "\n" + dis[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnReadInputRegisters_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            ReadCoilsView form = new ReadCoilsView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    ushort[] irs = await _factory.ReadInputRegisters(form.UnitId, form.StartAddress, form.NumberOfPoints);
                    if (irs != null)
                    {
                        for (int i = 0; i < irs.Length; i++)
                        {
                            tbInfo.Text += "\n" + irs[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnWriteSingleCoil_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            WriteSingleCoilView form = new WriteSingleCoilView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    await _factory.WriteSingleCoil(form.UnitID, form.StartAddress, form.Value);
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnWrireMultiCoils_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            WriteMultiCoilsView form = new WriteMultiCoilsView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    await _factory.WriteMultipleCoils(form.UnitId, form.StartAddress, form.Values);
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnWriteSingleHoldingRegister_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            WriteSingleHoldingRegisterView form = new WriteSingleHoldingRegisterView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    await _factory.WriteSingleHoldingRegisters(form.UnitID, form.Address, form.Value);
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void btnReadMultiHoldingRegisters_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionService.Client == null || _factory.Master == null || !_connectionService.Client.Connected)
            {
                MessageBox.Show("Master is not connected to slave.");
                return;
            }
            tbInfo.Text = string.Empty;
            ReadCoilsView form = new ReadCoilsView();
            if (form.ShowDialog() == true)
            {
                try
                {
                    ushort[] irs = await _factory.ReadMultipleHoldingRegisters(form.UnitId, form.StartAddress, form.NumberOfPoints);
                    if (irs != null)
                    {
                        for (int i = 0; i < irs.Length; i++)
                        {
                            tbInfo.Text += "\n" + irs[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbInfo.Text = ex.Message;
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (device1!=null) {
                Device1View device1View = new Device1View(
                    await device1.GrindingStep.Temperature.GetProcessValue(),
                    await device1.GrindingStep.Time.GetProcessValue(),
                    await device1.GrindingStep.GrindingMethod.GetProcessValue(),
                    await device1.SaharificationStep.Temperature.GetProcessValue(),
                    await device1.SaharificationStep.Time.GetProcessValue(),
                    await device1.SaharificationStep.Method.GetProcessValue(),
                    await device1.MashoutStep.Temperature.GetProcessValue(),
                    await device1.MashoutStep.Time.GetProcessValue(),
                    await device1.FilteringStep.Temperature.GetProcessValue(),
                    await device1.FilteringStep.Time.GetProcessValue()
                    );
                device1View.TemperatureSet += SetTemperature;
                device1View.TimeSet += SetTime;
                device1View.MethodSet += SetMethod;
                device1View.ShowDialog();
            }
            else
            {
                MessageBox.Show("Connect first.");
            }
        }
        private  void SetTemperature(object sender, TemperatureSetEventArgs e) {
            if (e.Stage == 1) {
                device1.GrindingStep.Temperature.SetValue(e.Temperature);
            }
            else if(e.Stage == 2)
            {
                device1.SaharificationStep.Temperature.SetValue(e.Temperature);
            }
            else if (e.Stage == 3)
            {
                device1.MashoutStep.Temperature.SetValue(e.Temperature);
            }
            else if (e.Stage == 4)
            {
                device1.FilteringStep.Temperature.SetValue(e.Temperature);
            }
        }
        private  void SetTime(object sender, TimeSetEventArgs e)
        {
            if (e.Stage == 1)
            {
                device1.GrindingStep.Time.SetValue(e.Time);
            }
            else if (e.Stage == 2)
            {
                device1.SaharificationStep.Time.SetValue(e.Time);
            }
            else if (e.Stage == 3)
            {
                device1.MashoutStep.Time.SetValue(e.Time);
            }
            else if (e.Stage == 4)
            {
                device1.FilteringStep.Time.SetValue(e.Time);
            }
        }
        private  void SetMethod(object sender, MethodSetEventArgs e)
        {
            if (e.Stage == 1)
            {
                device1.GrindingStep.GrindingMethod.SetValue(e.Method);
            }
            else if (e.Stage == 2)
            {
                device1.SaharificationStep.Method.SetValue(e.Method);
            }
        }
    }
}
