using NModbus;
using NModbus.Data;
using NModbus.Device;
using Slave.Commands;
using Slave.Interfaces;
using Slave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Slave.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IConnectionService _connectionService;
        private ISlaveFactory _factory;
        private Device _device;
        IModbusSlave _slave;
        #region registers
        private ushort _grindingTempreatureHR;
        public ushort GrindingTemperatureHR
        {
            get
            {
                return _grindingTempreatureHR;
            }
            set
            {
                _grindingTempreatureHR = value;
                OnPropertyChanged(nameof(GrindingTemperatureHR));
            }
        }

        private ushort _grindingTimeHR;
        public ushort GrindingTimeHR
        {
            get
            {
                return _grindingTimeHR;
            }
            set
            {
                _grindingTimeHR = value;
                OnPropertyChanged(nameof(GrindingTimeHR));
            }
        }

        private ushort _grindingMethodHR;
        public ushort GrindingMethodHR
        {
            get
            {
                return _grindingMethodHR;
            }
            set
            {
                _grindingMethodHR = value;
                OnPropertyChanged(nameof(GrindingMethodHR));
            }
        }

        private ushort _saharificationTempreatureHR;
        public ushort SaharificationTemperatureHR
        {
            get
            {
                return _saharificationTempreatureHR;
            }
            set
            {
                _saharificationTempreatureHR = value;
                OnPropertyChanged(nameof(SaharificationTemperatureHR));
            }
        }

        private ushort _saharificationTimeHR;
        public ushort SaharificationTimeHR
        {
            get
            {
                return _saharificationTimeHR;
            }
            set
            {
                _saharificationTimeHR = value;
                OnPropertyChanged(nameof(SaharificationTimeHR));
            }
        }

        private ushort _saharificationMetodHR;
        public ushort SaharificationMethodHR
        {
            get
            {
                return _saharificationMetodHR;
            }
            set
            {
                _saharificationMetodHR = value;
                OnPropertyChanged(nameof(SaharificationMethodHR));
            }
        }

        private ushort _mashoutTempreatureHR;
        public ushort MashoutTemperatureHR
        {
            get
            {
                return _mashoutTempreatureHR;
            }
            set
            {
                _mashoutTempreatureHR = value;
                OnPropertyChanged(nameof(MashoutTemperatureHR));
            }
        }

        private ushort _mashoutTimeHR;
        public ushort MashoutTimeHR
        {
            get
            {
                return _mashoutTimeHR;
            }
            set
            {
                _mashoutTimeHR = value;
                OnPropertyChanged(nameof(MashoutTimeHR));
            }
        }

        private ushort _filteringTempreatureHR;
        public ushort FilteringTemperatureHR
        {
            get
            {
                return _filteringTempreatureHR;
            }
            set
            {
                _filteringTempreatureHR = value;
                OnPropertyChanged(nameof(FilteringTemperatureHR));
            }
        }

        private ushort _filteringTimeHR;
        public ushort FilteringTimeHR
        {
            get
            {
                return _filteringTimeHR;
            }
            set
            {
                _filteringTimeHR = value;
                OnPropertyChanged(nameof(FilteringTimeHR));
            }
        }

        private ushort _grindingTempreatureIR;
        public ushort GrindingTemperatureIR
        {
            get
            {
                return _grindingTempreatureIR;
            }
            set
            {
                _grindingTempreatureIR = value;
                OnPropertyChanged(nameof(GrindingTemperatureIR));
            }
        }

        private ushort _grindingTimeIR;
        public ushort GrindingTimeIR
        {
            get
            {
                return _grindingTimeIR;
            }
            set
            {
                _grindingTimeIR = value;
                OnPropertyChanged(nameof(GrindingTimeIR));
            }
        }

        private ushort _grindingMethodIR;
        public ushort GrindingMethodIR
        {
            get
            {
                return _grindingMethodIR;
            }
            set
            {
                _grindingMethodIR = value;
                OnPropertyChanged(nameof(GrindingMethodIR));
            }
        }

        private ushort _saharificationTempreatureIR;
        public ushort SaharificationTemperatureIR
        {
            get
            {
                return _saharificationTempreatureIR;
            }
            set
            {
                _saharificationTempreatureIR = value;
                OnPropertyChanged(nameof(SaharificationTemperatureIR));
            }
        }

        private ushort _saharificationTimeIR;
        public ushort SaharificationTimeIR
        {
            get
            {
                return _saharificationTimeIR;
            }
            set
            {
                _saharificationTimeIR = value;
                OnPropertyChanged(nameof(SaharificationTimeIR));
            }
        }

        private ushort _saharificationMetodIR;
        public ushort SaharificationMethodIR
        {
            get
            {
                return _saharificationMetodIR;
            }
            set
            {
                _saharificationMetodIR = value;
                OnPropertyChanged(nameof(SaharificationMethodIR));
            }
        }

        private ushort _mashoutTempreatureIR;
        public ushort MashoutTemperatureIR
        {
            get
            {
                return _mashoutTempreatureIR;
            }
            set
            {
                _mashoutTempreatureIR = value;
                OnPropertyChanged(nameof(MashoutTemperatureIR));
            }
        }

        private ushort _mashoutTimeIR;
        public ushort MashoutTimeIR
        {
            get
            {
                return _mashoutTimeIR;
            }
            set
            {
                _mashoutTimeIR = value;
                OnPropertyChanged(nameof(MashoutTimeIR));
            }
        }

        private ushort _filteringTempreatureIR;
        public ushort FilteringTemperatureIR
        {
            get
            {
                return _filteringTempreatureIR;
            }
            set
            {
                _filteringTempreatureIR = value;
                OnPropertyChanged(nameof(FilteringTemperatureIR));
            }
        }

        private ushort _filteringTimeIR;
        public ushort FilteringTimeIR
        {
            get
            {
                return _filteringTimeIR;
            }
            set
            {
                _filteringTimeIR = value;
                OnPropertyChanged(nameof(FilteringTimeIR));
            }
        }
        #endregion

        public ICommand StartCommand { get; }
        public ICommand SetInputRegisterCommand { get; }
        public MainViewModel(IConnectionService connectionService, ISlaveFactory factory)
        {
            _device = new Device();
            _connectionService = connectionService;
            _factory = factory;
            StartCommand = new StartCommand(_connectionService, _factory, _device, this);
            SetInputRegisterCommand = new SetInputRegisterCommand(_device, this);
        }
        public void UpdateDeviceValues(IModbusSlave slave)
        {
            _slave=slave;
            
            ((SlaveDataStore)_slave.DataStore).HoldingRegisters.AfterWrite +=(sender, args) => {
                SetRegistersAfterWrite(args.StartAddress);
            };
            ((SlaveDataStore)_slave.DataStore).InputRegisters.AfterWrite += (sender, args) => {
                SetRegistersAfterWrite(args.StartAddress);
            };
        }
        private void SetRegistersAfterWrite(ushort address) {
            if (address == 40001) {
                GrindingMethodHR = _device.GrindingMethodRegisters.ReadHoldingRegister();
            }
            else if (address == 40002)
            {
                GrindingTemperatureHR = _device.GrindingTemperatureRegisters.ReadHoldingRegister();

            }
            else if (address == 40003)
            {
                GrindingTimeHR = _device.GrindingTimeRegisters.ReadHoldingRegister();

            }
            else if (address == 40004)
            {
                SaharificationMethodHR = _device.SaharificationMethodRegisters.ReadHoldingRegister();
            }
            else if (address == 40005)
            {
                SaharificationTemperatureHR = _device.SaharificationTemperatureRegisters.ReadHoldingRegister();
            }
            else if (address == 40006)
            {
                SaharificationTimeHR = _device.SaharificationTimeRegisters.ReadHoldingRegister();
            }else if (address == 40007)
            {
                MashoutTemperatureHR = _device.MashoutTemperatureRegisters.ReadHoldingRegister();            }
            else if (address == 40008)
            {
                MashoutTimeHR = _device.MashoutTimeRegisters.ReadHoldingRegister();            }
            else if (address == 40009)
            {
                FilteringTemperatureHR = _device.FilteringTemperatureRegisters.ReadHoldingRegister();
            }
            else if (address == 40010)
            {
                FilteringTimeHR = _device.FilteringTimeRegisters.ReadHoldingRegister();
            }
            else if (address == 30001)
            {
                GrindingMethodIR = _device.GrindingMethodRegisters.ReadInputRegister();
            }
            else if (address == 30002)
            {
                GrindingTemperatureIR = _device.GrindingTemperatureRegisters.ReadInputRegister();

            }
            else if (address == 30003)
            {
                GrindingTimeIR = _device.GrindingTimeRegisters.ReadInputRegister();
            }
            else if (address == 30004)
            {
                SaharificationMethodIR = _device.SaharificationMethodRegisters.ReadInputRegister();
            }
            else if (address == 30005)
            {
                SaharificationTemperatureIR = _device.SaharificationTemperatureRegisters.ReadInputRegister();
            }
            else if (address == 30006)
            {
                SaharificationTimeIR = _device.SaharificationTimeRegisters.ReadInputRegister();
            }
            else if (address == 30007)
            {
                MashoutTemperatureIR = _device.MashoutTemperatureRegisters.ReadInputRegister();
            }
            else if (address == 30008)
            {
                MashoutTimeIR = _device.MashoutTimeRegisters.ReadInputRegister();
            }
            else if (address == 30009)
            {
                FilteringTemperatureIR = _device.FilteringTemperatureRegisters.ReadInputRegister();
            }
            else if (address == 30010)
            {
                FilteringTimeIR = _device.FilteringTimeRegisters.ReadInputRegister();
            }
        }

    }
}
