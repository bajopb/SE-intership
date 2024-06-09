using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Interfaces
{
    internal interface IConnectionService
    {
        TcpListener Listener { get; }
        Task<TcpListener> Connect();
        void Disconnect();
    }
}
