using Backend.Models.Enums;
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
    public class SetPoint
    {
        public byte DeviceId { get; private set; }
        public StepType StepType { get; private set; }
        public ProcessType ProcessType { get; private set; }
        /// <summary>
        /// Address of the holding register.
        /// </summary>
        public ushort HoldingRegister { get;  set; }
        /// <summary>
        /// Address of the input register.
        /// </summary>
        public ushort InputRegister { get;  set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SetPoint"/> class.
        /// </summary>
        /// <param name="masterService">The master service for Modbus operations.</param>
        /// <param name="deviceId">The ID of the Modbus device.</param>
        /// <param name="holdingRegisterAddress">The address of the holding register.</param>
        /// <param name="inputRegisterAddress">The address of the input register.</param>
        public SetPoint(byte deviceId, StepType stepType, ProcessType processType, ushort holdingRegisterAddress, ushort inputRegisterAddress) {
            HoldingRegister = holdingRegisterAddress;
            InputRegister = inputRegisterAddress;
            DeviceId = deviceId;
            StepType = stepType;
            ProcessType = processType;
        }
    }
}
