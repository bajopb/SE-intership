using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Interfaces
{
    /// <summary>
    /// Interface for managing a TCP connection.
    /// </summary>
    public interface IConnectionService
    {
        /// <summary>
        /// Gets the TCP listener used for the connection.
        /// </summary>
        TcpListener Listener { get; }
        /// <summary>
        /// Connects to the remote server asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation. The task result contains the TCP listener.</returns>
        Task<TcpListener> Connect();
        /// <summary>
        /// Disconnects from the remote server.
        /// </summary>
        void Disconnect();
    }
}
