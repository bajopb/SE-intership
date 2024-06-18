using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.ProcessSteps
{
    public interface IStep
    {
        IDevice Device { get; }

    }
}
