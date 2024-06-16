using Master.Interfaces;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public class FilteringStep
    {
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public IMasteraFactoryService Master { get; set; }
        public FilteringStep(IMasteraFactoryService master, byte deviceId, ushort temperatureHRAddress, ushort temperatureIRAddress, ushort timeHRAddress, ushort timeIRAddress) {
            Master = master;
            Temperature = new SetPoint(Master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(Master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
