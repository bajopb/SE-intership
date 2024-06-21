using Backend.CommandExecutor;
using Backend.Commands;
using Backend.Commands.CommandResult;
using Backend.Interfaces;
using Backend.Models.Enums;
using Master.Commands;
using Master.Interfaces;
using Master.Models;
using Master.Services;
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
        //TODO
        //lista uredjaja
        //metoda ConfigToDevice
        private CommandExecutor _commandExecutor;
        public ObservableCollection<Device1ViewModel> Devices { get; set; }
        public ICommand ConnectCommand { get; }
        public ICommand ShowDevice { get; }
        public MainViewModel() {
            Devices = new ObservableCollection<Device1ViewModel>();
            _commandExecutor = new CommandExecutor();
            Connect();
        }
        private async Task Connect()
        {
            ConnectCommandResult res = await _commandExecutor.Connect();
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
                Devices.Add(new Device1ViewModel(ConfigToDevices(item), _commandExecutor));
            }
        }

        public Device ConfigToDevices(ConfigItem item) 
        {
            return new Device(item.UnitID, item.Registers);
        }
    }
}
