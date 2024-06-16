using Master.Interfaces;
using Master.Models;
using Master.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Master.Commands
{
    public class ConnectCommand : CommandBase
    {
        private readonly IConnectionService _connectionService;
        private IMasteraFactoryService _factoryService;
        private Device _device;
        public ConnectCommand(IConnectionService connectionService, IMasteraFactoryService masteraFactoryService, Device device) {
            _factoryService = masteraFactoryService;
            _connectionService = connectionService;
            _device = device;
        }
        public async override void Execute(object parameter)
        {
            var button = parameter as Button;

            if (_connectionService.Client == null || !_connectionService.Client.Connected)
            {

                await _connectionService.Connect();
                await _connectionService.Connect();
                _factoryService.Client = _connectionService.Client;
                _factoryService.CreateMaster();
                _device.SetRegistersForGrinding(1, 1, 2, 2, 3, 3);
                _device.SetRegistersForSaharification(4, 4, 5, 5, 6, 6);
                _device.SetRegistersForMashout(7, 7, 8, 8);
                _device.SetRegistersForFiltering(9, 9, 10, 10);
                _device.Master=_factoryService;
                button.Content = "Disconnect";
            }
            else
            {
                
                _connectionService.Disconect();
                button.Content = "Connect";

            }
        }
        public async Task Connect() {
        
        }
    }
}
