﻿using Master.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models.SecondStageModels
{
    public class GrindingStep
    {
        public SetPoint GrindingMethod { get; set; }
        public SetPoint Temperature { get; set; }
        public SetPoint Time { get; set; }
        public IMasteraFactoryService Master { get; set; }
        public GrindingStep(IMasteraFactoryService master, byte deviceId, ushort grindingMethodHRAddress, ushort grindingMethodIRAddress, ushort temperatureHRAddress, ushort temperatureIRAddress, 
            ushort timeHRAddress, ushort timeIRAddress)
        {
            Master = master;
            GrindingMethod = new SetPoint(Master, deviceId, grindingMethodHRAddress, grindingMethodIRAddress);
            Temperature = new SetPoint(Master, deviceId, temperatureHRAddress, temperatureIRAddress);
            Time = new SetPoint(Master, deviceId, timeHRAddress, timeIRAddress);
        }
    }
}
