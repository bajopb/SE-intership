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
        public MainViewModel() {
            Devices = new ObservableCollection<Device>();
            _commandExecutor = new CommandExecutor();
            Connect();
            Send = new RelayCommand(ExecuteSendCommand);
        }
        private async Task Connect()
        {
            var res = await _commandExecutor.Connect();
            List<ConfigItem> items = new List<ConfigItem>();
            foreach(var item in res.ConfigItems)
            {
                items.Add(new ConfigItem() { UnitID = item.UnitID, Registers = item.Registers });
            }
            InitializeDevicesCollection(items);
        }

        private void InitializeDevicesCollection(List<ConfigItem> items)
        {
            foreach(var item in items) {
                Devices.Add(new Device(item.UnitID, item.Registers));
            }
        }

        private void ExecuteSendCommand(object parameter)
        {
            if (parameter is SetPoint setPoint)
            {
                byte unitId = setPoint.DeviceId;
                StepType stepType = setPoint.StepType;
                ProcessType processType = setPoint.ProcessType;
                ushort holdingRegister = setPoint.HoldingRegister;

                
            }
        }

    }
}
