using Backend.Interfaces;
using Backend.Models.Enums;
using Master.Interfaces;
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

        public GrindingStep(Dictionary<ProcessType, List<ushort>> dic)
        {
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
                else if (kvp.Key == ProcessType.METHOD)
                {
                    Registers.Add(ProcessType.METHOD, new SetPoint(kvp.Value[0], kvp.Value[1]));
                }
            }
        }
    }
}
