using NModbus;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Interfaces
{
    internal interface ISlaveFactory
    {
        IModbusSlave CreateSlave(ISlaveDataStore store);
        void CreateSlaveNetwork(TcpListener listener);
        void AddSlave(IModbusSlave slave);
        IModbusSlaveNetwork SlaveNetwork { get; }
    }
}
