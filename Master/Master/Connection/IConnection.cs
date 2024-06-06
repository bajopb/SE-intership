using NModbus;
using NModbus.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Connection
{
    internal interface IConnection
    {

        abstract Task<IModbusMaster> Connect();
        abstract void Disconnect();
    }
}
