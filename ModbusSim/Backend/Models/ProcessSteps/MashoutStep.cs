using Backend.Interfaces;
using Backend.Models.Enums;
using Backend.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.ProcessSteps
{
    public class MashoutStep:IStep
    {
        public Dictionary<ProcessType, AnalogPoints> Registers { get; private set; }

        public IDevice Device { get; set; }
        public MashoutStep(IDevice device, Dictionary<ProcessType, List<ushort>> dic)
        {
            Device = device;
            Registers = new Dictionary<ProcessType, AnalogPoints>();
            SetRegisters(dic);
        }
        private void SetRegisters(Dictionary<ProcessType, List<ushort>> dic) {
            foreach (var kvp in dic)
            {
                if (kvp.Key == ProcessType.TEMPERATURE)
                {
                    Registers.Add(ProcessType.TEMPERATURE, new AnalogPoints(Device, kvp.Value[0], kvp.Value[1]));
                }
                else if (kvp.Key == ProcessType.TIME)
                {
                    Registers.Add(ProcessType.TIME, new AnalogPoints(Device, kvp.Value[0], kvp.Value[1]));
                }
            }
        }
    }
}
