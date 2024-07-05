using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Slave.Models.Points
{
    /// <summary>
    /// Represents analog points on Slave device.
    /// </summary>
    public class AnalogPoints : INotifyPropertyChanged
    {
        private ushort _holdingRegisterValue;
        /// <summary>
        /// Gets or sets the value of the holding register.
        /// </summary>
        public ushort HoldingRegisterValue
        {
            get => _holdingRegisterValue;
            set
            {
                _holdingRegisterValue = value;
                OnPropertyChanged(nameof(HoldingRegisterValue));
            }
        }
        /// <summary>
        /// Gets or sets the address of the holding register.
        /// </summary>
        public ushort HoldingRegisterAddress { get; set; }

        private ushort _inputRegisterValue;
        /// <summary>
        /// Gets or sets the value of the input register.
        /// </summary>
        public ushort InputRegisterValue
        {
            get => _inputRegisterValue;
            set
            {
                _inputRegisterValue = value;
                OnPropertyChanged(nameof(InputRegisterValue));
            }
        }
        /// <summary>
        /// Gets or sets the address of the input register.
        /// </summary>
        public ushort InputRegisterAddress { get; set; }

        public AnalogPoints(ushort holdingRegisterAddress, ushort inputRegisterAddress)
        {
            HoldingRegisterAddress = holdingRegisterAddress;
            InputRegisterAddress = inputRegisterAddress;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
