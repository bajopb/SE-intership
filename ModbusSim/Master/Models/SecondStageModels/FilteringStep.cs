using Backend.Models.Enums;
using Master.Interfaces;
using Microsoft.Win32;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public class FilteringStep:IStep
    {
        public Dictionary<ProcessType, SetPoint> Registers { get; private set; }

        public FilteringStep(Dictionary<ProcessType, List<ushort>> dic)
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
            }
        }
    }
}
