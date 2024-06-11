using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    internal class GrindingStep
    {
        public SetPoint GrindingMethod { get; set; }
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public GrindingStep(IMasteraFactoryService master, byte deviceId, ushort grindingMethodHRAddress, ushort grindingMethodIRAddress, ushort temperatureHRAddress, ushort temperatureIRAddress, 
            ushort timeHRAddress, ushort timeIRAddress)
        {
            GrindingMethod = new SetPoint(master, deviceId, grindingMethodHRAddress, grindingMethodIRAddress);
            Temperature = new SetPoint(master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
