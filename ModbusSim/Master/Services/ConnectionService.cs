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
        public TcpClient Client {get;private set;}

        public async Task Connect()
        {
            Client = new TcpClient();
            await Client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 13);
        }

        public void Disconect()
        {
            if (Client != null)
            {
                Client.Close();
            }
        }
    }
}
