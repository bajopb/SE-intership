using NModbus;
using Slave.Interfaces;
using Slave.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Models
{
    public class Device
    {
        public IModbusSlave Slave { get; set; }
        public byte DeviceID { get; set; }
        public AnalogPoints GrindingTemperatureRegisters { get; set; }
        public AnalogPoints SaharificationTemperatureRegisters { get; set; }
        public AnalogPoints MashoutTemperatureRegisters { get; set; }
        public AnalogPoints FilteringTemperatureRegisters { get; set; }
        public AnalogPoints GrindingTimeRegisters { get; set; }
        public AnalogPoints SaharificationTimeRegisters { get; set; }
        public AnalogPoints MashoutTimeRegisters { get; set; }
        public AnalogPoints FilteringTimeRegisters { get; set; }
        public AnalogPoints GrindingMethodRegisters { get; set; }
        public AnalogPoints SaharificationMethodRegisters { get; set; }
        public Device() { }
        public Device(IModbusSlave slave, byte deviceId) {
            Slave = slave;
            DeviceID = deviceId;
        }
        public void SetRegistersForGrinding(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            GrindingTemperatureRegisters = new AnalogPoints(Slave, temperatureHoldingRegister, tempreatureInputRegister);
            GrindingMethodRegisters = new AnalogPoints(Slave, methodHoldingRegister, methodInputRegister);
            GrindingTimeRegisters = new AnalogPoints(Slave, timeHoldingRegister, timeInputRegister);
        }
        public void SetRegistersForSaharification(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister) 
        {
            SaharificationTemperatureRegisters = new AnalogPoints(Slave, temperatureHoldingRegister, tempreatureInputRegister);
            SaharificationTimeRegisters = new AnalogPoints(Slave, timeHoldingRegister, timeInputRegister);
            SaharificationMethodRegisters = new AnalogPoints(Slave, methodHoldingRegister, methodInputRegister);
        }
        public void SetRegistersForMashout(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister) {
            MashoutTemperatureRegisters = new AnalogPoints(Slave, temperatureHoldingRegister, tempreatureInputRegister);
            MashoutTimeRegisters = new AnalogPoints(Slave, timeHoldingRegister, timeInputRegister);
        }
        public void SetRegistersForFiltering(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            FilteringTemperatureRegisters = new AnalogPoints(Slave, temperatureHoldingRegister, tempreatureInputRegister);
            FilteringTimeRegisters = new AnalogPoints(Slave, timeHoldingRegister, timeInputRegister);
        }
    }
}
