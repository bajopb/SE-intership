using Backend.Models.ProcessSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IDevice
    {
        int GlobalID { get; }
        IMasterFactoryService MasterFactory { get; }
        byte UnitID { get; }
        List<IStep> Steps { get; }
    }
}
