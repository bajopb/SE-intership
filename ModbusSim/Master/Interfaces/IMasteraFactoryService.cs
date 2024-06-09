using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Master.Interfaces
{
    internal interface IMasteraFactoryService
    {
        IModbusMaster Master { get; }
        IModbusMaster CreateMaster();
        Task<bool[]> ReadCoils(byte slaveId, ushort startAddress, ushort numberOfPoints);
        Task<bool[]> ReadDiscreteInputs(byte slaveId, ushort startAddress, ushort numberOfPoints);
        Task<ushort[]> ReadInputRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints);
        Task<ushort[]> ReadMultipleHoldingRegisters(byte slaveId, ushort startAddress, ushort numberOfPoints);
        Task WriteSingleCoil(byte slaveId, ushort startAddress, bool value);
        Task WriteMultipleCoils (byte slaveId, ushort startAddress, bool[] values);
        Task WriteSingleHoldingRegisters(byte slaveId, ushort startAddress, ushort value);
    }
}
