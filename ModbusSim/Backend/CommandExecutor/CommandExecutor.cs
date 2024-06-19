using Backend.Commands;
using Backend.Commands.CommandResult;
using Backend.Configuration;
using Backend.Connection;
using Backend.Interfaces;
using Backend.MasterServices;
using Backend.Models.Enums;
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
        public Dictionary<int, IDevice> DeviceCollection { get; private set; }
        public CommandExecutor() {
            configuration=new ConfigReader();
            _connection = new Connection.Connection();
        }
        public async Task<ConnectCommandResult> Connect()
        {
            await _connection.Connect(configuration.Address, configuration.Port);
            if (_connection.Client.Connected)
            {
                return new ConnectCommandResult("Connected", true);
            }
            else
            {
                return new ConnectCommandResult("Connection error.", true);
            }
        }
    }
}
