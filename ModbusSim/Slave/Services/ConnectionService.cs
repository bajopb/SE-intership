using Slave.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Services
{
    internal class ConnectionService : IConnectionService
    {
        private TcpListener listener;
        
        public async Task<TcpListener> Connect()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 13);
            listener = new(ipEndPoint);
            listener.Start();
            return listener;
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
