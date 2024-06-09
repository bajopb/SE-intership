using Master.Interfaces;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.Services
{
    class MasterFactoryService: IMasteraFactoryService
    {
        private TcpClient _tcpClient;
        private IModbusFactory _modbusFactory;
        public IModbusMaster Master { get; private set; }
        public MasterFactoryService(TcpClient tcpClient) {
            _tcpClient = tcpClient;
            _modbusFactory = new ModbusFactory();
        }

        public IModbusMaster CreateMaster()
        {
            Master= _modbusFactory.CreateMaster(_tcpClient);
            return Master;
        }
        public async Task<bool[]> ReadCoils(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    bool[] coils=await Master.ReadCoilsAsync(slaveId, startAddress, numberOfPoints);
                    return coils;
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
            return null;
        }

        public async Task<bool[]> ReadDiscreteInputs(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    bool[] dis = await Master.ReadInputsAsync(slaveId, (ushort)(10000+startAddress), numberOfPoints);
                    return dis;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
            return null;
        }

        public async Task<ushort[]> ReadInputRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] irs = await Master.ReadInputRegistersAsync(slaveId, (ushort)(30000 + startAddress), numberOfPoints);
                    return irs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
            return null;
        }

        public  async Task<ushort[]> ReadMultipleHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints)
        {
            if (Master != null)
            {
                try
                {
                    ushort[] hrs = await Master.ReadHoldingRegistersAsync(slaveId, (ushort)(40000 + startAddress), numberOfPoints);
                    return hrs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
            return null;
        }

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
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
        }

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
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
        }

        public async Task WriteSingleHoldingRegisters(byte slaveId, ushort startAddress, ushort value)
        {
            if (Master != null)
            {
                try
                {
                    await Master.WriteSingleRegisterAsync(slaveId, (ushort)(40000 + startAddress), value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Master is null.");
            }
        }
    }
}
