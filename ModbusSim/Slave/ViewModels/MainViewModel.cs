using Backend.CommandExecutor;
using Backend.Connection;
using Backend.EventArgs;
using NModbus;
using NModbus.Data;
using NModbus.Device;
using Slave.Commands;
using Slave.Models;
using Slave.Models.Points;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Slave.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IConnection _connectionService;
        private SlaveExecutor _executor;
        public ObservableCollection<Device> Devices { get; set; }       
        public ICommand SetIRValueCommand {  get; set; }
        private Device _selectedDevice;
        public Device SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged(nameof(SelectedDevice));
                LoadRegisterValues();
            }
        }
        private ushort _inputRegisterValue=0;
        public ushort InputRegisterValue
        {
            get { return _inputRegisterValue; }
            set
            {
                _inputRegisterValue = value;
                OnPropertyChanged(nameof(InputRegisterValue));
            }
        }
        public MainViewModel()
        {
            _executor=new SlaveExecutor();
            _executor.DataStoreChanged += OnDataStoreChanged;
            Connect();
            SetIRValueCommand = new RelayCommand(SetInputRegister);
        }

        private async Task Connect()
        {
            var res = await _executor.Connect();
            List<ConfigItem> items = new List<ConfigItem>();
            foreach (var item in res.ConfigItems)
            {
                items.Add(new ConfigItem() { UnitID = item.UnitID, Registers = item.Registers });
            }
            InitializeDevicesCollection(items);
        }
        private void InitializeDevicesCollection(List<ConfigItem> items)
        {
            Devices = new ObservableCollection<Device>();
            foreach (var item in items)
            {
                Devices.Add(new Device(item.UnitID, item.Registers));
            }
        }
        private void LoadRegisterValues()
        {
            if (_selectedDevice != null)
            {
                Dictionary<ushort, ushort> dic= _executor.GetRegistersValuesForDevice(SelectedDevice.DeviceID, SelectedDevice.GetAllAdresses());
                foreach(var kvp in dic)
                {
                    SelectedDevice.SetRegisterValue(kvp.Key, kvp.Value);
                }
                OnPropertyChanged(nameof(SelectedDevice));
            }
        }
        private void SetInputRegister(object parameter)
        {
            if (parameter is AnalogPoints point)
            {
                _executor.WriteRegisterValueForDevice(SelectedDevice.DeviceID, point.InputRegisterAddress, point.InputRegisterValue);
                InputRegisterValue = 0;
            }
        }
        private void OnDataStoreChanged(object sender, DataStoreChangedEventArgs e)
        {
            if (_selectedDevice != null && _selectedDevice.DeviceID == e.UnitID)
            {
                var addresses = SelectedDevice.GetAllAdresses().Where(addr => addr == e.StartAddress).ToList();
                if (addresses.Any())
                {
                    var values = _executor.GetRegistersValuesForDevice(e.UnitID, addresses);
                    foreach (var kvp in values)
                    {
                        SelectedDevice.SetRegisterValue(kvp.Key, kvp.Value);
                    }
                    OnPropertyChanged(nameof(SelectedDevice));
                }
            }
        }
    }
}
