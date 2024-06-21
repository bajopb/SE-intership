using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    public class ConfigItem
    {
        public byte UnitID { get;  set; }
        public Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> Registers { get;  set; }
    }
}
