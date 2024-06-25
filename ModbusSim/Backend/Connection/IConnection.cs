using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Connection
{
    /// <summary>
    /// Interface for managing a TCP connection.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Connects to the remote server asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        Task Connect(string address, int port);
        /// <summary>
        /// Disconnects from the remote server.
        /// </summary>
        void Disconnect();
        bool IsConnected();
    }
}
