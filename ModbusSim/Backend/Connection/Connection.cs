using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Connection
{
    /// <summary>
    /// Class for managing a TCP connection.
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Gets the TCP client used for the connection.
        /// </summary>
        public TcpClient Client { get; private set; }
        /// <summary>
        /// Connects to the remote server asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
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
        /// <summary>
        /// Disconnects from the remote server.
        /// </summary>
        public void Disconect()
        {
            if (Client != null)
            {
                Client.Close();
            }
        }
    }
}
