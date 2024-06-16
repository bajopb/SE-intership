using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.Services
{
    /// <summary>
    /// Class for managing a TCP connection.
    /// </summary>
    public class ConnectionService : IConnectionService
    {
        /// <summary>
        /// Gets the TCP client used for the connection.
        /// </summary>
        public TcpClient Client { get; private set; }
        /// <summary>
        /// Connects to the remote server asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        public async Task Connect()
        {
            Client = new TcpClient();
            await Client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 13);            
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
