using Backend.Commands.CommandResult;
using Backend.Configuration;
using Backend.Connection;
using Backend.EventArgs;
using Backend.Interfaces;
using Backend.MasterServices;
using Backend.SlaveServices;
using NModbus;
using NModbus.Data;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CommandExecutor
{
    /// <summary>
    /// Provides functionality to manage Slave devices.
    /// </summary>
    public class SlaveExecutor
    {
        private IConfiguration configuration;
        private readonly IConnection _connection;
        private ISlaveService SlaveService { get;  set; }
        private Dictionary<byte, IModbusSlave> SlaveCollection { get;  set; }
        /// <summary>
        /// Occurs when the Slave data store changes.
        /// </summary>
        public event EventHandler<DataStoreChangedEventArgs> DataStoreChanged;
        public SlaveExecutor()
        {
            configuration = new ConfigReader();
            _connection = new SlaveConnection();
            SlaveService = new SlaveService();
            SlaveCollection=new Dictionary<byte, IModbusSlave>();
        }
        /// <summary>
        /// Connects to the Master.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the connection result.</returns>
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
                            SubscribeToDataStoreEvents(SlaveCollection[item.UnitID]);
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
        /// <summary>
        /// Gets the values of specified registers for a given device.
        /// </summary>
        /// <param name="deviceId">The unit ID of the device.</param>
        /// <param name="addresses">The list of register addresses.</param>
        /// <returns>A dictionary containing register addresses and their corresponding values.</returns>
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
        /// <summary>
        /// Writes a value to a specified register for a given device.
        /// </summary>
        /// <param name="deviceId">The unit ID of the device.</param>
        /// <param name="address">The register address.</param>
        /// <param name="value">The value to write.</param>
        public void WriteRegisterValueForDevice(byte devicId, ushort address, ushort value) {
            SlaveCollection[devicId].DataStore.InputRegisters.WritePoints(address, new ushort[] { value });
        }
        private async Task StartListening()
        {
            await SlaveService.SlaveNetwork.ListenAsync();
        }
        private void SubscribeToDataStoreEvents(IModbusSlave slave)
        {
            ((SlaveDataStore)slave.DataStore).HoldingRegisters.AfterWrite += (sender, args) => OnDataStoreChanged(sender, args, slave.UnitId);
            ((SlaveDataStore)slave.DataStore).InputRegisters.AfterWrite += (sender, args) => OnDataStoreChanged(sender, args, slave.UnitId);
        }
        private void OnDataStoreChanged(object sender, PointEventArgs args, byte unitID)
        {
            DataStoreChanged?.Invoke(this, new DataStoreChangedEventArgs(unitID, args.StartAddress, args.NumberOfPoints));
        }

    }
}
