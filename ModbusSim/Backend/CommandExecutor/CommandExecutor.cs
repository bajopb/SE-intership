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
    /// <summary>
    /// Provides functionality to execute Master commands.
    /// </summary>
    public class CommandExecutor
    {
        private IConfiguration configuration;
        private readonly IConnection _connection;
        private IMasterService MasterService { get;  set; }
        public CommandExecutor() {
            configuration=new ConfigReader();
            _connection = new MasterConnection();
            MasterService= new MasterService();
        }
        /// <summary>
        /// Connects to the Slave.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the connection result.</returns>
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
                return new ConnectCommandResult("Connection error.", false) ;
            }
        }
        /// <summary>
        /// Reads a value from a specified register address.
        /// </summary>
        /// <param name="unitId">The unit ID of the device.</param>
        /// <param name="address">The register address.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the read result.</returns>
        public async Task<ReadCommandResult> Read(byte unitId, ushort address)
        {
            if (!MasterService.Client.Connected)
            {
                return new ReadCommandResult(false, "Slave is not connected.");
            }
            if (GetRegType(address) == RegType.INPUT_REG)
            {
                try
                {
                    ushort value = await (MasterService.ReadSingleInputRegister(unitId, address));
                    return new ReadCommandResult(true, "", value);
                }
                catch (Exception ex)
                {
                    return new ReadCommandResult(false, ex.Message.ToString());
                }
            }
            if (GetRegType(address) == RegType.HOLDING_REG)
            {
                try
                {
                    ushort value = await (MasterService.ReadSingleHoldingRegister(unitId, address));
                    return new ReadCommandResult(true, "", value);
                }
                catch(Exception ec)
                {
                    return new ReadCommandResult(false, ec.Message.ToString());
                }            
            }
            return new ReadCommandResult(false, "Invalid address.");
        }
        /// <summary>
        /// Writes a value to a specified holding register address.
        /// </summary>
        /// <param name="unitId">The unit ID of the device.</param>
        /// <param name="address">The register address.</param>
        /// <param name="value">The value to write.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the write result.</returns>
        public async Task<WriteCommandResult> Write(byte unitId, ushort address, ushort value)
        {
            if (GetRegType(address) == RegType.HOLDING_REG)
            {
                try
                {
                    await MasterService.WriteSingleHoldingRegisters(unitId, address, value);
                    return new WriteCommandResult(true, "");
                }
                catch (Exception ex)
                {
                    return new WriteCommandResult(false, ex.Message.ToString());
                }
            }
            else 
            {
                return new WriteCommandResult(false, "Input registers can not be written.");
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
