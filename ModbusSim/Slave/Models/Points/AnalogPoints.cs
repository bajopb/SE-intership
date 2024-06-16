using NModbus;
using Slave.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Models.Points
{
    public class AnalogPoints
    {
        private readonly IModbusSlave _slave;
        public ushort HoldingRegister { get; set; }
        public ushort InputRegister { get; set; }
        public AnalogPoints(IModbusSlave slave, ushort holdingRegister, ushort inputRegister) {
            _slave = slave;
            HoldingRegister = holdingRegister;
            InputRegister = inputRegister;
        }
        public ushort ReadHoldingRegister() {
            return _slave.DataStore.HoldingRegisters.ReadPoints(HoldingRegister, 1)[0];
        }
        public ushort ReadInputRegister()
        {
            return _slave.DataStore.InputRegisters.ReadPoints(InputRegister, 1)[0];
        }
        public void WriteHoldingRegister(ushort value)
        {
            _slave.DataStore.HoldingRegisters.WritePoints(HoldingRegister, new ushort[] { value});
        }
        public void WriteInputRegister(ushort value)
        {
            _slave.DataStore.InputRegisters.WritePoints(InputRegister, new ushort[] { value });
        }
    }
}
