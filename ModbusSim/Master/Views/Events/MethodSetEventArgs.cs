using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Views.Events
{
    public class MethodSetEventArgs:EventArgs
    {
        public ushort Method { get; }
        public int Stage { get; }

        public MethodSetEventArgs(ushort method, int stage)
        {
            Method = method;
            Stage = stage;
        }
    }
}
