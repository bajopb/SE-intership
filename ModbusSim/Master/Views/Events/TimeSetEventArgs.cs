using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Views.Events
{
    public class TimeSetEventArgs:EventArgs
    {
        public ushort Time { get; }
        public int  Stage { get; }

        public TimeSetEventArgs(ushort time, int stage)
        {
            Time = time;
            Stage = stage;
        }
    }
}
