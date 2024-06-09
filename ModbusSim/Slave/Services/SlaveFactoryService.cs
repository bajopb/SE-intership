using NModbus;
using NModbus.Data;
using NModbus.Device;
using Slave.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Services
{
    internal class SlaveFactoryService : ISlaveFactory
    {
        private IModbusFactory _factory;
        public IModbusSlaveNetwork SlaveNetwork { get; set; }
        public SlaveFactoryService(IModbusFactory factory)
        {
            _factory=factory;
        }
        public void AddSlave(IModbusSlave slave)
        {
            SlaveNetwork.AddSlave(slave);
        }

        public IModbusSlave CreateSlave(ISlaveDataStore store)
        {
            IModbusSlave slave = _factory.CreateSlave(1,store);
            slave.DataStore.CoilDiscretes.WritePoints(1, new bool[] { true, false, true });
            slave.DataStore.CoilInputs.WritePoints(10001, new bool[] { true, false, true });
            slave.DataStore.InputRegisters.WritePoints(30001, new ushort[] { 100, 1000, 10000 });
            slave.DataStore.HoldingRegisters.WritePoints(40001, new ushort[] { 100, 1000, 10000 });
            return slave;
        }

        public void CreateSlaveNetwork(TcpListener listener)
        {
            SlaveNetwork = _factory.CreateSlaveNetwork(listener);
        }
    }
}
