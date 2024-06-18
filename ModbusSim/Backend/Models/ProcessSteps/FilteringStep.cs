using Backend.Interfaces;
using Backend.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.ProcessSteps
{
    public class FilteringStep:IStep
    {
        public AnalogPoints? TemperatureRegisters { get; set; }
        public AnalogPoints? TimeRegisters { get; set; }
        public IDevice Device { get; set; }
        public FilteringStep(IDevice device, ushort temperatureHoldingRegisters, ushort temperatureInputRegisters, 
            ushort timeHoldingRegisters, ushort timeInputRegisters)
        {
            Device = device;
            TemperatureRegisters = new AnalogPoints(Device, temperatureHoldingRegisters, temperatureInputRegisters);
            TimeRegisters = new AnalogPoints(Device, timeHoldingRegisters, timeInputRegisters);
        }
    }
}
