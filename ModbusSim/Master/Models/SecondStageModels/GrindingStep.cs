using Backend.Interfaces;
using Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public class GrindingStep:IStep
    {
        public Dictionary<ProcessType, SetPoint> Registers { get; private set; }

        public byte DeviceId { get; private set; }
        public StepType StepType { get; private set; }
        public ProcessType ProcessType { get; private set; }

        public GrindingStep(byte deviceId,StepType stepType, Dictionary<ProcessType, List<ushort>> dic)
        {
            StepType = stepType;
            StepType=stepType;
            Registers = new Dictionary<ProcessType, SetPoint>();
            SetRegisters(dic);
        }
        private void SetRegisters(Dictionary<ProcessType, List<ushort>> dic)
        {
            foreach (var kvp in dic)
            {
                if (kvp.Key == ProcessType.TEMPERATURE)
                {
                    Registers.Add(ProcessType.TEMPERATURE, new SetPoint(DeviceId, StepType, ProcessType.TEMPERATURE, kvp.Value[0], kvp.Value[1]));
                }
                else if (kvp.Key == ProcessType.TIME)
                {
                    Registers.Add(ProcessType.TIME, new SetPoint(DeviceId, StepType, ProcessType.TIME, kvp.Value[0], kvp.Value[1]));
                }
                else if (kvp.Key == ProcessType.METHOD)
                {
                    Registers.Add(ProcessType.METHOD, new SetPoint(DeviceId, StepType, ProcessType.METHOD, kvp.Value[0], kvp.Value[1]));
                }
            }
        }
    }
}
