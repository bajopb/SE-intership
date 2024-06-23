using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.MasterServices
{
    public class MasterService:IMasterService
    {
        private IModbusFactory _modbusFactory;
        /// <summary>
        /// Represents the current Modbus Master.
        /// </summary>
        public IModbusMaster Master { get; private set; }

        public TcpClient Client { get; set; }

        /// <summary>
        /// Creates a new instance of the Modbus Master.
        /// </summary>
        /// <returns>A new instance of the Modbus Master.</returns>
        public IModbusMaster CreateMaster()
        {
            Master = _modbusFactory.CreateMaster(Client);
            return Master;
        }
        public MasterService()
        {
            _modbusFactory = new ModbusFactory();
        }
        public MasterService(TcpClient tcpClient)
        {
            Client = tcpClient;
        }
        /// <summary>
        /// Reads coils from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of boolean values read from the device.</returns>
        public async Task<bool[]> ReadCoils(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    bool[] coils = await Master.ReadCoilsAsync(slaveId, startAddress, numberOfPoints);
                    return coils;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            return null;
        }
        /// <summary>
        /// Reads discrete inputs from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of boolean values read from the device.</returns>
        public async Task<bool[]> ReadDiscreteInputs(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    bool[] dis = await Master.ReadInputsAsync(slaveId, startAddress, numberOfPoints);
                    return dis;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            return null;
        }
        /// <summary>
        /// Reads input registers from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of ushort values read from the device.</returns>
        public async Task<ushort[]> ReadInputRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] irs = await Master.ReadInputRegistersAsync(slaveId, startAddress, numberOfPoints);
                    return irs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            return null;
        }
        /// <summary>
        /// Reads holding registers from a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start reading from.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an array of ushort values read from the device.</returns>
        public async Task<ushort[]> ReadMultipleHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] hrs = await Master.ReadHoldingRegistersAsync(slaveId, startAddress, numberOfPoints);
                    return hrs;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            return null;
        }
        /// /// <summary>
        /// Writes multiple coils to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to start writing to.</param>
        /// <param name="values">The values to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task WriteMultipleCoils(byte slaveId, ushort startAddress, bool[] values)
        {
            if (Master != null)
            {
                try
                {
                    await Master.WriteMultipleCoilsAsync(slaveId, startAddress, values);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
        }
        /// <summary>
        /// Writes a single coil to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task WriteSingleCoil(byte slaveId, ushort startAddress, bool value)
        {
            if (Master != null)
            {
                try
                {
                    await Master.WriteSingleCoilAsync(slaveId, startAddress, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
        }
        /// <summary>
        /// Writes a single holding register to a Modbus slave device.
        /// </summary>
        /// <param name="slaveId">The ID of the slave device.</param>
        /// <param name="startAddress">The address to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task WriteSingleHoldingRegisters(byte slaveId, ushort startAddress, ushort value)
        {
            if (Master != null)
            {
                try
                {
                    await Master.WriteSingleRegisterAsync(slaveId, startAddress, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
        }

        public async Task<ushort> ReadSingleHoldingRegister(byte slaveId, ushort startAddress)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] hrs = await Master.ReadHoldingRegistersAsync(slaveId, startAddress, 1);
                    return hrs[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            throw new Exception("");
        }
        public async Task<ushort> ReadSingleInputRegister(byte slaveId, ushort startAddress)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] hrs = await Master.ReadInputRegistersAsync(slaveId, startAddress, 1);
                    return hrs[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error: Master is null.");
            }
            throw new Exception("");
        }
    }
}
