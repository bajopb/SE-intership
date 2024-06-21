using Backend.Commands;
using Backend.Commands.CommandResult;
using Backend.Configuration;
using Backend.Connection;
using Backend.Interfaces;
using Backend.MasterServices;
using Backend.Models.Devices;
using Backend.Models.Enums;
using Backend.Models.ProcessSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CommandExecutor
{
    public class CommandExecutor
    {
        private IConfiguration configuration;
        private readonly IConnection _connection;
        public IMasterService MasterService { get; private set; }
        public Dictionary<byte, IDevice> DeviceCollection { get; private set; }
        public CommandExecutor() {
            configuration=new ConfigReader();
            _connection = new Connection.Connection();
            MasterService= new MasterService();
        }
        public async Task<ConnectCommandResult> Connect()
        {
            await _connection.Connect(configuration.Address, configuration.Port);
            if (_connection.Client.Connected)
            {
                MasterService.Client=_connection.Client;
                MasterService.CreateMaster();
                List<IConfigItem> list= configuration.GetConfigurationItems();
                return new ConnectCommandResult("Connected", true, list);
            }
            else
            {
                return new ConnectCommandResult("Connection error.", true, null);
            }
        }
        
        private void SetDeviceCollection(List<IConfigItem> list)
        {
            foreach (IConfigItem item in list)
            {
                DeviceCollection.Add(item.UnitID, new Device1(MasterService, item.UnitID, item.Registers));
                
            }
        }
    }
}
