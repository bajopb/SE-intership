﻿using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IConfigItem
    {
        byte UnitID { get; }
        Dictionary<StepType, List<ushort>> Registers { get; }
    }
}
