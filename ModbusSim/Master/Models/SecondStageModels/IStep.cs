using Backend.Interfaces;
using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public interface IStep
    {
        StepType StepType { get; }
        Dictionary<ProcessType, SetPoint> Registers { get; }
    }
}
