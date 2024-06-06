using NModbus;
using NModbus.Data;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Factory
{
    internal class SlaveFactory : ISlaveFactory
    {
        private IModbusFactory factory;

        IModbusSlave slave;

        public SlaveFactory() { 
            factory = new ModbusFactory();
        }

        public IModbusSlave CreateSlave(ISlaveDataStore store)
        {
            slave = factory.CreateSlave(1, store);
            slave.DataStore.CoilDiscretes.WritePoints(1, new bool[] { true, false, true });
            slave.DataStore.CoilInputs.WritePoints(10001, new bool[] { true, false, true });
            slave.DataStore.InputRegisters.WritePoints(30001, new ushort[] { 100, 1000, 10000 });
            slave.DataStore.HoldingRegisters.WritePoints(40001, new ushort[] { 100, 1000, 10000 });
            return slave;
        }   

        public IModbusSlaveNetwork CreateSlaveNetwork(TcpListener listener)
        {
            return factory.CreateSlaveNetwork(listener);
        }

        
    }
}
