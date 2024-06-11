using Master.Interfaces;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.Models
{
    internal class SetPoint
    {
        private IMasteraFactoryService _masterService;
        private byte deviceId;
        public ushort HoldingRegister { get; private set; }
        public ushort InputRegister { get; private set; }
        public SetPoint(IMasteraFactoryService masterService, byte deviceId, ushort holdingRegisterAddress, ushort inputRegisterAddress) {
            HoldingRegister = holdingRegisterAddress;
            InputRegister = inputRegisterAddress;
            this.deviceId = deviceId;
            _masterService = masterService;
        }

        public void SetValue(ushort value) {
            if (_masterService.Master == null)
            {
                MessageBox.Show("Master is not connected.");
                return;
            }
            _masterService.WriteSingleHoldingRegisters(deviceId, HoldingRegister, value);
        }
        public async Task<ushort> GetProcessValue()
        {
            if (_masterService.Master == null)
            {
                throw new Exception("Master is not connected.");
            }
            else
            {
                return (await _masterService.ReadInputRegisters(deviceId, InputRegister, 1))[0] ;
            }
        }
    }
}
