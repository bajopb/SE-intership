using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Connection
{
    /// <summary>
    /// Represents the Master connection logic and the implementation of <see cref="IConnection"/>.
    /// </summary>
    public class MasterConnection : IConnection
    {
        public TcpClient Client {  get; set; }
        public async Task Connect(string address, int port)
        {
            Client = new TcpClient();

            while (!Client.Connected)
            {
                try
                {
                    if (!Client.Connected)
                    {
                        await Client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 13);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Disconnect()
        {
            if (Client != null)
            {
                Client.Close();
            }
        }

        public bool IsConnected()
        {
            return Client != null && Client.Connected;
        }
    }
}
