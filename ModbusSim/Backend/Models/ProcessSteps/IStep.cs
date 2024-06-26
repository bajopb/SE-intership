﻿using Backend.Interfaces;
using Backend.Models.Enums;
using Backend.Models.Points;
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
        Dictionary<ProcessType, AnalogPoints> Registers { get; }
    }
}
