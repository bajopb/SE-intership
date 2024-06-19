using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Enums
{
    public enum StepType
    {
        GRINDING_S=1,
        SAHARIFICATION_S=2,
        MASHOUT_S=3,
        FILTERING_S=4,
    }
    public enum ConnectionState
    {
        CONNECTED,
        DISCONNECTED,
    }
}
