using NModbus.Data;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SlaveServices
{
    public class SlaveService:ISlaveService
    {
        private IModbusFactory _factory;
        public IModbusSlaveNetwork SlaveNetwork { get; set; }
        public SlaveService()
        {
            _factory = new ModbusFactory();
        }
        

        public IModbusSlave CreateSlave(byte id)
        {
            SlaveDataStore store = new SlaveDataStore();
            IModbusSlave slave = _factory.CreateSlave( id, store);
            SlaveNetwork.AddSlave(slave);
            return slave;
        }

        public void CreateSlaveNetwork(TcpListener listener)
        {
            SlaveNetwork = _factory.CreateSlaveNetwork(listener);
        }
    }
}
