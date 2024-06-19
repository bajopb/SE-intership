using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.MasterServices
{
    /// <summary>
    /// Interface for Master Service.
    /// </summary>
    public interface IMasterService
    {
        TcpClient Client { get; set; }
        /// <summary>
        /// Represents the current Modbus Master.
        /// </summary>
        IModbusMaster Master { get; }
        /// <summary>
        /// Creates a new instance of the Modbus Master.
        /// </summary>
        /// <returns>A new instance of the Modbus Master.</returns>
        IModbusMaster CreateMaster();
        /// <summary>
        /// Reads coils from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of boolean values read from the device.</returns>
        Task<bool[]> ReadCoils(byte slaveId, ushort startAddress, ushort numberOfPoints);
        /// <summary>
        /// Reads discrete inputs from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of boolean values read from the device.</returns>
        Task<bool[]> ReadDiscreteInputs(byte slaveId, ushort startAddress, ushort numberOfPoints);
        /// <summary>
        /// Reads input registers from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of ushort values read from the device.</returns>
        Task<ushort[]> ReadInputRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints);
        /// <summary>
        /// Reads holding registers from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of ushort values read from the device.</returns>
        Task<ushort[]> ReadMultipleHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints);
        /// <summary>
        /// Writes a single coil to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task WriteSingleCoil(byte slaveId, ushort startAddress, bool value);
        /// <summary>
        /// Writes multiple coils to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start writing to.</param>
        /// <param name="values">The values to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task WriteMultipleCoils(byte slaveId, ushort startAddress, bool[] values);
        /// <summary>
        /// Writes a single holding register to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task WriteSingleHoldingRegisters(byte slaveId, ushort startAddress, ushort value);
    }
}
