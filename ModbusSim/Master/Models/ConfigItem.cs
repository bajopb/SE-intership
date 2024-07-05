using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    /// <summary>
    /// Represents a configuration item for a Modbus device on the Master UI.
    /// </summary>
    public class ConfigItem
    {
        /// <summary>
        /// Gets the unit ID of the Modbus device.
        /// </summary>
        public byte UnitID { get;  set; }
        /// <summary>
        /// Gets the registers for the Modbus device, organized by step type and process type.
        /// </summary>
        public Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> Registers { get;  set; }
    }
}
