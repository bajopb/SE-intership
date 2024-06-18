using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Points
{
    public class AnalogPoints
    {
        private IDevice _device;
        public int GlobalID=>_device.GlobalID;
        public ushort HoldingRegister { get; set; }
        public ushort InputRegister { get; set; }
        public AnalogPoints(IDevice device, ushort holdingRegisterAddress, ushort inputRegisterAddress)
        {
            _device = device;
            HoldingRegister = holdingRegisterAddress;
            InputRegister = inputRegisterAddress;
        }


    }
}
