using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Connection
{
    internal interface IConnection
    {
        abstract Task<TcpListener> Connect();
        abstract void Disconnect();
    }
}
