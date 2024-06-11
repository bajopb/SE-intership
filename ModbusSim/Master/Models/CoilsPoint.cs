using Master.Interfaces;
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
        private IMasteraFactoryService _masterService;
        private Device _device;
        public ushort Coil { get; private set; }
        public ushort DiscreteInput { get; private set; }
        public CoilsPoint(IMasteraFactoryService masterService, Device device, ushort holdingRegisterAddress, ushort inputRegisterAddress)
        {
            Coil = holdingRegisterAddress;
            DiscreteInput = inputRegisterAddress;
            _device = device;
            _masterService = masterService;
        }

        public void SetValue(bool value)
        {
            if (_masterService.Master == null)
            {
                throw new Exception("Master is not connected.");
            }
            _masterService.WriteSingleCoil(_device.UnitId, Coil, value);
        }
        public async Task<bool> GetProcessValue()
        {
            if (_masterService.Master == null)
            {
                throw new Exception("Master is not connected.");
            }
            else
            {
                return (await _masterService.ReadCoils(_device.UnitId, DiscreteInput, 1))[0];
            }
        }
    }
}
