using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Views.Events
{
    public class TemperatureSetEventArgs:EventArgs
    {
        public ushort Temperature { get; }
        public int Stage { get; }

        public TemperatureSetEventArgs(ushort temperature, int stage)
        {
            Temperature = temperature;
            Stage = stage;
        }
    }
}
