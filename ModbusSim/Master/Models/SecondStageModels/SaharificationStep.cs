using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    internal class SaharificationStep
    {
        public SetPoint Method { get; set; }
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public SaharificationStep(IMasteraFactoryService master, byte deviceId, ushort modeHRAddress,  ushort modeIRAddress, ushort temperatureHRAddress, ushort temperatureIRAddress, ushort timeHRAddress, ushort timeIRAddress)
        {
            Method = new SetPoint(master, deviceId, modeHRAddress, modeIRAddress);
            Temperature = new SetPoint(master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
