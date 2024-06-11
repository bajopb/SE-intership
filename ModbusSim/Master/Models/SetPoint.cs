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
    /// <summary>
    /// Represents a set point for interacting with Slave registers.
    /// </summary>
    internal class SetPoint
    {
        private IMasteraFactoryService _masterService;
        private byte deviceId;
        /// <summary>
        /// Address of the holding register.
        /// </summary>
        public ushort HoldingRegister { get; private set; }
        /// <summary>
        /// Address of the input register.
        /// </summary>
        public ushort InputRegister { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetPoint"/> class.
        /// </summary>
        /// <param name="masterService">The master service for Modbus operations.</param>
        /// <param name="deviceId">The ID of the Modbus device.</param>
        /// <param name="holdingRegisterAddress">The address of the holding register.</param>
        /// <param name="inputRegisterAddress">The address of the input register.</param>
        public SetPoint(IMasteraFactoryService masterService, byte deviceId, ushort holdingRegisterAddress, ushort inputRegisterAddress) {
            HoldingRegister = holdingRegisterAddress;
            InputRegister = inputRegisterAddress;
            this.deviceId = deviceId;
            _masterService = masterService;
        }
        /// <summary>
        /// Sets the value of the holding register.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(ushort value) {
            if (_masterService.Master == null)
            {
                MessageBox.Show("Master is not connected.");
                return;
            }
            _masterService.WriteSingleHoldingRegisters(deviceId, HoldingRegister, value);
        }
        /// <summary>
        /// Gets the value from the input register.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains the value from the input register.</returns>
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
