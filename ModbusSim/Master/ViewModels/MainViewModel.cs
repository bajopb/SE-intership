using Backend.CommandExecutor;
using Backend.Commands;
using Backend.Interfaces;
using Backend.Models.Enums;
using Master.Commands;
using Master.Models;
using Master.Models.SecondStageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Master.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private CommandExecutor _commandExecutor;
        public ObservableCollection<Device> Devices { get; set; }
        public ICommand Send {  get; set; }
        public ICommand LoadIRValueCommand { get; }
        public MainViewModel() {
            Devices = new ObservableCollection<Device>();
            _commandExecutor = new CommandExecutor();
            ConnectionState = ConnectionState.DISCONNECTED;
            Connect();
            Send = new RelayCommand(ExecuteSendCommand);
            LoadIRValueCommand = new RelayCommand(ExecuteLoadIRValue);
        }
        private async Task Connect()
        {
            var res = await _commandExecutor.Connect();
            if (res.IsSuccess)
            {
                List<ConfigItem> items = new List<ConfigItem>();
                foreach (var item in res.ConfigItems)
                {
                    items.Add(new ConfigItem() { UnitID = item.UnitID, Registers = item.Registers });
                }
                InitializeDevicesCollection(items);
                ConnectionState = ConnectionState.CONNECTED;
            }
            else
            {
                MessageBox.Show(res.Message);
            }
        }

        private void InitializeDevicesCollection(List<ConfigItem> items)
        {
            foreach(var item in items) {
                Devices.Add(new Device(item.UnitID, item.Registers));
            }
        }

        private async void ExecuteSendCommand(object parameter)
        {
            if (parameter is SetPoint setPoint)
            {
                var res=await _commandExecutor.Write(SelectedDevice.UnitId, setPoint.HoldingRegisterAddress, setPoint.HoldingRegisterValue);
                if (!res.IsSuccess)
                {
                    MessageBox.Show(res.Message);
                }
            }
        }
        private async void ExecuteLoadIRValue(object parameter)
        {
            if (parameter is SetPoint setPoint)
            {
                var res = await _commandExecutor.Read(SelectedDevice.UnitId, setPoint.InputRegisterAddress);
                if (!res.IsSuccess)
                {
                    MessageBox.Show(res.Message);
                }
                else
                {
                    SelectedDevice.SetRegisterValue(setPoint.InputRegisterAddress, res.Value);
                }
            }
        }

        private Device _selectedDevice;
        public Device SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                OnPropertyChanged(nameof(SelectedDevice));
            }
        }

        private ConnectionState _connectionState;
        public ConnectionState ConnectionState
        {
            get
            {
                return _connectionState;
            }
            set
            {
                _connectionState = value;
                OnPropertyChanged(nameof(ConnectionState));
            }
        }

    }
}
