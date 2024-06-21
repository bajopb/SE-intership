using Backend.MasterServices;
using Backend.Models.Enums;
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
        IMasterService MasterService { get; }
        byte UnitID { get; }
        Dictionary<StepType, IStep> Steps { get; }
    }
}
