using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slave.Models.Points
{
    using System.ComponentModel;

    public class AnalogPoints : INotifyPropertyChanged
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
