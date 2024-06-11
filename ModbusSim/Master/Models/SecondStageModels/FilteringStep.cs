using Master.Interfaces;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    internal class FilteringStep
    {
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public FilteringStep(IMasteraFactoryService master, byte deviceId, ushort temperatureHRAddress, ushort temperatureIRAddress, ushort timeHRAddress, ushort timeIRAddress) {
            Temperature = new SetPoint(master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
