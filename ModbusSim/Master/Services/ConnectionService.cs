using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Services
{
    class ConnectionService : IConnectionService
    {
        public async Task<TcpClient> Connect()
        {
            TcpClient client = new();
            await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 13);
            return client;
        }

        public void Disconect()
        {
            throw new NotImplementedException();
        }
    }
}
