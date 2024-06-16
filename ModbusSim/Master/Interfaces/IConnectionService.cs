using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Master.Interfaces

{
    /// <summary>
    /// Interface for managing a TCP connection.
    /// </summary>
    public interface IConnectionService
    {
        /// <summary>
        /// Gets the TCP client used for the connection.
        /// </summary>
        TcpClient Client { get; }
        /// <summary>
        /// Connects to the remote server asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        Task Connect();
        /// <summary>
        /// Disconnects from the remote server.
        /// </summary>
        void Disconect();
    }
}
