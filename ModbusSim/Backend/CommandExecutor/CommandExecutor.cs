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
            _connection = new MasterConnection();
            MasterService= new MasterService();
        }
        public async Task<ConnectCommandResult> Connect()
        {
            await _connection.Connect(configuration.Address, configuration.Port);
            if (_connection.IsConnected())
            {
                if(_connection is MasterConnection connection)
                MasterService.Client=connection.Client;
                MasterService.CreateMaster();
                List<IConfigItem> list= configuration.GetConfigurationItems();
                return new ConnectCommandResult("Connected", true, list);
            }
            else
            {
                return new ConnectCommandResult("Connection error.", false, null) ;
            }
        }
        public async Task<ushort> Read(byte unitId, StepType stepType, ProcessType processType, ushort address)
        {
            if (GetRegType(address) == RegType.INPUT_REG)
            {
                return await (MasterService.ReadSingleInputRegister(unitId, address));
            }
            throw new NotImplementedException();
        }
        public async Task Write(byte unitId, StepType stepType, ProcessType processType, ushort address, ushort value)
        {
            if (GetRegType(address) == RegType.HOLDING_REG)
            {
                await MasterService.WriteSingleHoldingRegisters(unitId, address, value);
            }
            else 
            { 
                throw new NotImplementedException();
            }
        }

        private RegType GetRegType(ushort address){
            if (address > 40000)
                return RegType.HOLDING_REG;
            else if (address > 30000)
                return RegType.INPUT_REG;
            throw new ArgumentException("Incorrect address.");
        }
    }
}
