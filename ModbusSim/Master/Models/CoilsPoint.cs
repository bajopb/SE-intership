using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.Models
{
    internal class CoilsPoint
    {
        private Device _device;
        public ushort Coil { get; private set; }
        public ushort DiscreteInput { get; private set; }
        public CoilsPoint(Device device, ushort holdingRegisterAddress, ushort inputRegisterAddress)
        {
            Coil = holdingRegisterAddress;
            DiscreteInput = inputRegisterAddress;
            _device = device;
        }
    }
}
