using Backend.Commands.CommandResult;
using Backend.Configuration;
using Backend.Connection;
using Backend.Interfaces;
using Backend.MasterServices;
using Backend.SlaveServices;
using NModbus;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CommandExecutor
{
    public class SlaveExecutor
    {
        private IConfiguration configuration;
        private readonly IConnection _connection;
        public ISlaveService SlaveService { get; private set; }
        public Dictionary<byte, IModbusSlave> SlaveCollection { get; private set; }
        public SlaveExecutor()
        {
            configuration = new ConfigReader();
            _connection = new SlaveConnection();
            SlaveService = new SlaveService();
            SlaveCollection=new Dictionary<byte, IModbusSlave>();
        }
        public async Task<ConnectCommandResult> Connect()
        {
            await _connection.Connect(configuration.Address, configuration.Port);
            if (_connection.IsConnected())
            {
                List<IConfigItem> list = configuration.GetConfigurationItems();
                if (_connection is SlaveConnection connection)
                {
                    SlaveService.CreateSlaveNetwork(connection.Listener);
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            SlaveCollection.Add(item.UnitID, SlaveService.CreateSlave(item.UnitID));
                        }
                        StartListening();
                    }
                }
                return new ConnectCommandResult("Connected", true, list);

            }
            else
            {
                return new ConnectCommandResult("Connection error.", false);
            }
        }
        public Dictionary<ushort, ushort> GetRegistersValuesForDevice(byte deviceId, List<ushort> addresses)
        {
            Dictionary<ushort, ushort> values = new Dictionary<ushort, ushort>();
            foreach (var address in addresses)
            {
                if (address > 40000)
                {
                    values.Add(address, SlaveCollection[deviceId].DataStore.HoldingRegisters.ReadPoints(address, 1)[0]);
                }
                else if (address > 30000)
                {
                    values.Add(address, SlaveCollection[deviceId].DataStore.InputRegisters.ReadPoints(address, 1)[0]);

                }
            }
            return values;
        }
        public void WriteRegisterValueForDevice(byte devicId, ushort address, ushort value) {
            SlaveCollection[devicId].DataStore.InputRegisters.WritePoints(address, new ushort[] { value });
        }
        private async Task StartListening()
        {
            await SlaveService.SlaveNetwork.ListenAsync();
        }

        
    }
}
