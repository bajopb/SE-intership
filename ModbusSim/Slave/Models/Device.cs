using Backend.Models.Enums;
using NModbus;
using Slave.Models.Points;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Models
{
    /// <summary>
    /// Represents a device with registers mapped to steps and processes.
    /// </summary>
    public class Device : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the ID of the device.
        /// </summary>
        public byte DeviceID { get; private set; }
        private Dictionary<StepType, Dictionary<ProcessType, AnalogPoints>> _registers;
        /// <summary>
        /// Gets or sets the registers mapped to steps and processes.
        /// </summary>
        public Dictionary<StepType, Dictionary<ProcessType, AnalogPoints>> Registers
        {
            get => _registers;
            private set
            {
                _registers = value;
                OnPropertyChanged(nameof(Registers));
            }
        }

        public Device(byte deviceId, Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic)
        {
            DeviceID = deviceId;
            Registers = new Dictionary<StepType, Dictionary<ProcessType, AnalogPoints>>();
            foreach (var kvp in dic)
            {
                Registers.Add(kvp.Key, SetAnalogPoints(kvp.Value));
            }
        }
        /// <summary>
        /// Gets all register addresses in the device.
        /// </summary>
        /// <returns>A list of register addresses.</returns>
        public List<ushort> GetAllAdresses()
        {
            List<ushort> addresses = new List<ushort>();
            foreach (var step in Registers)
            {
                foreach (var process in step.Value)
                {
                    addresses.Add(process.Value.HoldingRegisterAddress);
                    addresses.Add(process.Value.InputRegisterAddress);
                }
            }
            return addresses;
        }
        /// <summary>
        /// Sets the value of a register based on its address.
        /// </summary>
        /// <param name="address">The address of the register.</param>
        /// <param name="value">The value to set.</param>
        public void SetRegisterValue(ushort address, ushort value)
        {
            foreach (var step in Registers)
            {
                foreach (var process in step.Value)
                {
                    if (process.Value.HoldingRegisterAddress == address)
                    {
                        process.Value.HoldingRegisterValue = value;
                        OnPropertyChanged(nameof(Registers));
                    }
                    if (process.Value.InputRegisterAddress == address)
                    {
                        process.Value.InputRegisterValue = value;
                        OnPropertyChanged(nameof(Registers));
                    }
                }
            }
        }

        private Dictionary<ProcessType, AnalogPoints> SetAnalogPoints(Dictionary<ProcessType, List<ushort>> dic)
        {
            Dictionary<ProcessType, AnalogPoints> res = new Dictionary<ProcessType, AnalogPoints>();
            foreach (var item in dic)
            {
                res.Add(item.Key, new AnalogPoints(item.Value[0], item.Value[1]));
            }
            return res;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
