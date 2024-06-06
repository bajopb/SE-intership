using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Factory
{
    internal interface ISlaveFactory
    {
        abstract IModbusSlave CreateSlave(ISlaveDataStore store);
        abstract IModbusSlaveNetwork CreateSlaveNetwork(TcpListener listener);

    }
}
