using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Factory
{
    internal class MasterFactory : IMasterFactory
    {
        private IModbusFactory factory;

        public MasterFactory() { 
            factory=new ModbusFactory();
        }
        public IModbusMaster CreateTcpMaster(TcpClient client)
        {
            return factory.CreateMaster(client);
        }
    }
}
