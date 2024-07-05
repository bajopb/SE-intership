using Backend.Models.Enums;
using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.Models
{
    /// <summary>
    /// Represents a set point for interacting with Slave registers.
    /// </summary>
    public class SetPoint:INotifyPropertyChanged
    {
        private ushort _holdingRegisterValue;
        public ushort HoldingRegisterValue
        {
            get => _holdingRegisterValue;
            set
            {
                _holdingRegisterValue = value;
                OnPropertyChanged(nameof(HoldingRegisterValue));
            }
        }

        public ushort HoldingRegisterAddress { get; set; }

        private ushort _inputRegisterValue;
        public ushort InputRegisterValue
        {
            get => _inputRegisterValue;
            set
            {
                _inputRegisterValue = value;
                OnPropertyChanged(nameof(InputRegisterValue));
            }
        }

        public ushort InputRegisterAddress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetPoint"/> class.
        /// </summary>
        /// <param name="masterService">The master service for Modbus operations.</param>
        /// <param name="deviceId">The ID of the Modbus device.</param>
        /// <param name="holdingRegisterAddress">The address of the holding register.</param>
        /// <param name="inputRegisterAddress">The address of the input register.</param>
        public SetPoint(ushort holdingRegisterAddress, ushort inputRegisterAddress) {
            HoldingRegisterAddress = holdingRegisterAddress;
            InputRegisterAddress = inputRegisterAddress;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
