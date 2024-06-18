using Backend.Interfaces;
using Backend.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.ProcessSteps
{
    public class SaharificationStep:IStep
    {
        public AnalogPoints? TemperatureRegisters { get; set; }
        public AnalogPoints? TimeRegisters { get; set; }
        public IDevice Device { get; set; }
        public AnalogPoints? MethodRegisters { get; set; }
        public SaharificationStep(IDevice device, ushort temperatureHoldingRegisters, ushort temperatureInputRegisters,
            ushort timeHoldingRegisters, ushort timeInputRegisters,
            ushort methodHoldingRegister, ushort methodInputRegister)
        {
            Device = device;
            TemperatureRegisters = new AnalogPoints(Device, temperatureHoldingRegisters, temperatureInputRegisters);
            TimeRegisters = new AnalogPoints(Device, timeHoldingRegisters, timeInputRegisters);
            MethodRegisters=new AnalogPoints(device, methodHoldingRegister, methodInputRegister);
        }
    }
}
