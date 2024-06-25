using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend.SlaveServices
{
    public interface ISlaveService
    {
        /// <summary>
        /// Gets the Modbus slave network.
        /// </summary>
        IModbusSlaveNetwork SlaveNetwork { get; }
        /// <summary>
        /// Creates a Modbus slave instance.
        /// </summary>
        /// <returns>A new instance of the Modbus slave.</returns>
        IModbusSlave CreateSlave(byte id);
        /// <summary>
        /// Creates a Modbus slave network using the specified TCP listener.
        /// </summary>
        /// <param name="listener">The TCP listener to be used for the slave network.</param>
        void CreateSlaveNetwork(TcpListener listener);
    }
}
