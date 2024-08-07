﻿using Backend.Models.Enums;
using System.Collections.Generic;

namespace Master.Models.SecondStageModels
{
    /// <summary>
    /// Represents a filtering step.
    /// </summary>
    public class FilteringStep:IStep
    {
        public Dictionary<ProcessType, SetPoint> Registers { get; private set; }

        public byte DeviceId { get; private set; }
        public StepType StepType { get; private set; }
        public ProcessType ProcessType { get; private set; }

        public FilteringStep(byte deviceId, StepType stepType, Dictionary<ProcessType, List<ushort>> dic)
        {
            StepType = stepType;
            DeviceId = deviceId;
            StepType = stepType;
            Registers = new Dictionary<ProcessType, SetPoint>();
            SetRegisters(dic);
        }
        private void SetRegisters(Dictionary<ProcessType, List<ushort>> dic)
        {
            foreach (var kvp in dic)
            {
                if (kvp.Key == ProcessType.TEMPERATURE)
                {
                    Registers.Add(ProcessType.TEMPERATURE, new SetPoint(kvp.Value[0], kvp.Value[1]));
                }
                else if (kvp.Key == ProcessType.TIME)
                {
                    Registers.Add(ProcessType.TIME, new SetPoint(kvp.Value[0], kvp.Value[1]));
                }
            }
        }
    }
}
