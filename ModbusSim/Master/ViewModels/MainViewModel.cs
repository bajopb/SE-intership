using Backend.CommandExecutor;
using Backend.Commands;
using Backend.Interfaces;
using Backend.Models.Enums;
using Backend.Models.ProcessSteps;
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
                byte unitId = setPoint.DeviceId;
                StepType stepType = setPoint.StepType;
                ProcessType processType = setPoint.ProcessType;
                ushort holdingRegister = setPoint.HoldingRegister;
                var res=await _commandExecutor.Write((byte)(unitId+1), stepType, processType, holdingRegister, HRValue);
                if (res.IsSuccess)
                {
                    HRValue = 0;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }
        private async void ExecuteLoadIRValue(object parameter)
        {
            if (parameter is SetPoint setPoint)
            {
                byte unitId = setPoint.DeviceId;
                StepType stepType = setPoint.StepType;
                ProcessType processType = setPoint.ProcessType;
                ushort inputRegister = setPoint.InputRegister;
                var res = await _commandExecutor.Read((byte)(unitId + 1), stepType, processType, inputRegister);
                if(res.IsSuccess)
                {
                    IRValue = res.Value;
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }


        private ushort irValue;
        public ushort IRValue
        {
            get 
            {
                return irValue;    
            }
            set 
            {
                irValue = value; 
                OnPropertyChanged(nameof(IRValue));
            }
        }
        private ushort hrValue;
        public ushort HRValue
        {
            get
            {
                return hrValue;
            }
            set
            {
                hrValue = value;
                OnPropertyChanged(nameof(HRValue));
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
