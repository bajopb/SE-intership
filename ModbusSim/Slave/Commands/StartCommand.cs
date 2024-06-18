using NModbus;
using Slave.Interfaces;
using Slave.Models;
using Slave.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Slave.Commands
{
    public class StartCommand : CommandBase
    {
        private readonly IConnectionService _connectionService;
        private readonly ISlaveFactory _factory;
        private MainViewModel _viewModel;
        private Device _device;
        private IModbusSlave _slave;
        public StartCommand(IConnectionService connection, ISlaveFactory factory, Device device, MainViewModel viewModel)
        {
            _connectionService = connection;
            _factory = factory;
            _device = device;
            _viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            var button = parameter as Button;
            if (_connectionService.Listener == null)
            {
                await _connectionService.Connect();
                _factory.CreateSlaveNetwork(_connectionService.Listener);
                _slave = _factory.CreateSlave();
                _factory.SlaveNetwork.AddSlave(_slave);
                _device.Slave=_slave;
                _device.DeviceID = 1;
                _device.SetRegistersForGrinding(40001, 30001, 40002, 30002,40003, 30003);
                _device.SetRegistersForSaharification(40004, 30004, 40005, 30005, 40006, 30006);
                _device.SetRegistersForMashout(40007, 30007, 40008, 30008);
                _device.SetRegistersForFiltering(40009, 30009, 40010, 30010);
                ListenAsync();
                button.Content = "Stop";
                _viewModel.UpdateDeviceValues(_slave);
            }
            else
            {
                _connectionService.Disconnect();
                button.Content = "Start";
            }
        }

        private async Task ListenAsync()
        {
            await _factory.SlaveNetwork.ListenAsync();
        }
    }
}
