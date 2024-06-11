using NModbus;
using NModbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Interfaces
{
    /// <summary>
    /// Interface for managing Modbus slaves.
    /// </summary>
    internal interface ISlaveFactory
    {
        /// <summary>
        /// Gets the Modbus slave network.
        /// </summary>
        IModbusSlaveNetwork SlaveNetwork { get; }
        /// <summary>
        /// Creates a Modbus slave instance.
        /// </summary>
        /// <returns>A new instance of the Modbus slave.</returns>
        IModbusSlave CreateSlave();
        /// <summary>
        /// Creates a Modbus slave network using the specified TCP listener.
        /// </summary>
        /// <param name="listener">The TCP listener to be used for the slave network.</param>
        void CreateSlaveNetwork(TcpListener listener);
        /// <summary>
        /// Adds a Modbus slave to the slave network.
        /// </summary>
        /// <param name="slave">The Modbus slave to add.</param>
        void AddSlave(IModbusSlave slave);
    }
}
