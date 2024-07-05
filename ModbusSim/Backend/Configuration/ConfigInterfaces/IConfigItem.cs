using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    /// <summary>
    /// Represents a configuration item for a device.
    /// </summary>
    public interface IConfigItem
    {
        /// <summary>
        /// Gets the ID of the device.
        /// </summary>
        byte UnitID { get; }
        /// <summary>
        /// Gets the registers for the Modbus device, organized by step type and process type.
        /// </summary>
        public Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> Registers { get; }
    }
}
