using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    internal class MashoutStep
    {
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public MashoutStep(IMasteraFactoryService master, byte deviceId, ushort temperatureHRAddress, ushort temperatureIRAddress, ushort timeHRAddress, ushort timeIRAddress)
        {
            Temperature = new SetPoint(master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
