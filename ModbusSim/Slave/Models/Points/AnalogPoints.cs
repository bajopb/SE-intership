using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Models.Points
{
    public class AnalogPoints
    {
        public ushort HoldingRegisterAddress { get; set; }
        public ushort InputRegisterAddress { get; set; }
        public ushort HoldingRegisterValue { get; set; }
        public ushort InputRegisterValue { get; set; }
        public AnalogPoints(ushort holdingRegister, ushort inputRegister) {
            HoldingRegisterAddress = holdingRegister;
            InputRegisterAddress = inputRegister;
        }
    }
}
