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
    public class SlaveFactoryService : ISlaveFactory
    {
        private IModbusFactory _factory;
        public IModbusSlaveNetwork SlaveNetwork { get; set; }
        private byte slaveCounter = 0;
        public SlaveFactoryService()
        {
            _factory=new ModbusFactory();
        }
        public void AddSlave(IModbusSlave slave)
        {
            SlaveNetwork.AddSlave(slave);
        }

        public IModbusSlave CreateSlave()
        {
            SlaveDataStore store = new SlaveDataStore();
            IModbusSlave slave = _factory.CreateSlave(++slaveCounter,store);
            return slave;
        }

        public void CreateSlaveNetwork(TcpListener listener)
        {
            SlaveNetwork = _factory.CreateSlaveNetwork(listener);
        }
    }
}
