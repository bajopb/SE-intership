using Backend.Interfaces;
using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    /// <summary>
    /// Represents a step in the device, including its type and associated registers.
    /// </summary>
    public interface IStep
    {
        /// <summary>
        /// Gets the type of the step.
        /// </summary>
        StepType StepType { get; }

        /// <summary>
        /// Gets the dictionary of process types and their corresponding set points.
        /// </summary>
        Dictionary<ProcessType, SetPoint> Registers { get; }
    }

}
