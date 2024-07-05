using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    /// <summary>
    /// Represents the configuration for the Modbus connection.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets the IP address for connection.
        /// </summary>
        string Address { get;}
        /// <summary>
        /// Gets the port for listening.
        /// </summary>
        int Port { get;}
        /// <summary>
        /// Gets the configuration items for the Modbus connection.
        /// </summary>
        /// <returns>A list of configuration items.</returns>
        List<IConfigItem> GetConfigurationItems();
    }
}
