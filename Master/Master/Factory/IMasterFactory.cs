using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Factory
{
    internal interface IMasterFactory
    {
        abstract IModbusMaster CreateTcpMaster(TcpClient client);

    }
}
