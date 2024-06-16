using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public class SaharificationStep
    {
        public SetPoint Method { get; set; }
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public IMasteraFactoryService Master { get; set; }

        public SaharificationStep(IMasteraFactoryService master, byte deviceId, ushort modeHRAddress,  ushort modeIRAddress, ushort temperatureHRAddress, ushort temperatureIRAddress, ushort timeHRAddress, ushort timeIRAddress)
        {
            Master = master;
            Method = new SetPoint(Master, deviceId, modeHRAddress, modeIRAddress);
            Temperature = new SetPoint(Master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(Master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
