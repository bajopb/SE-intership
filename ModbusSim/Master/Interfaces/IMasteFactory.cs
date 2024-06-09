using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Interfaces
{
    interface IMasteFactory
    {
        IModbusMaster CreateMaster();
    }
}
