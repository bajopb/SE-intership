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
        /// Connects to the remote point asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        Task Connect(string address, int port);
        /// <summary>
        /// Disconnects from the remote point.
        /// </summary>
        void Disconnect();
        /// <summary>
        /// Checks if the connection is established.
        /// </summary>
        /// <returns>True if connected, otherwise false.</returns>
        bool IsConnected();
    }
}
