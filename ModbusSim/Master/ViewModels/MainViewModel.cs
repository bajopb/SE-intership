using Backend.CommandExecutor;
using Backend.Commands;
using Backend.Commands.CommandResult;
using Backend.Interfaces;
using Master.Commands;
using Master.Interfaces;
using Master.Models;
using Master.Services;
using System;
using System.Collections.Generic;
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
        private readonly IConnectionService _connectionService;
        private IMasteraFactoryService _factoryService;
        private Device _device;
        private CommandExecutor _commandExecutor;
        public ICommand ConnectCommand { get; }
        public ICommand ShowDevice { get; }
        public MainViewModel(IConnectionService connectionService, IMasteraFactoryService masteraFactoryService, Device device) {
            //_connectionService = connectionService;
            //_factoryService = masteraFactoryService;
            //_device = device;
            //ConnectCommand = new ConnectCommand(_connectionService, _factoryService, _device);
            //ShowDevice = new ShowDevice(_factoryService, _device);
            _commandExecutor = new CommandExecutor();
            Connect();
        }
        private async Task Connect()
        {
            ConnectCommandResult res = await _commandExecutor.Connect();
            MessageBox.Show(res.Message);
        }
    }
}
