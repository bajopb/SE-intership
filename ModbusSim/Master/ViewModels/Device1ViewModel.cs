using Master.Commands.SetterCommands;
using Master.Interfaces;
using Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Master.ViewModels
{
    public class Device1ViewModel:ViewModelBase
    {
        private Device _device;
        private readonly IMasteraFactoryService _factoryService;
        #region registers
        public byte DeviceID => _device.UnitId;
        public string Address => _device.IPAddress;
        public int Port => _device.Port;
        public ushort GrindingTemperatureIR { get; set; }
        public ushort GrindingTimeIR { get; set; }
        public ushort GrindingMethodIR { get; set; }
        public ushort SaharificationTemperatureIR { get; set; }
        public ushort SaharificationTimeIR { get; set; }
        public ushort SaharificationMethodIR { get; set; }
        public ushort MashoutTemperatureIR { get; set; }
        public ushort MashoutTimeIR { get; set; }
        public ushort FilteringTemperatureIR { get; set; }
        public ushort FilteringTimeIR { get; set; }

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
        #endregion
        public ICommand SetGrindingTemperatureCommand { get; }
        public ICommand SetGrindingTimeCommand { get; }
        public ICommand SetGrindingMethodCommand{ get; }
        public ICommand SetSaharificationTemperatureCommand { get; }
        public ICommand SetSaharificationTimeCommand { get; }
        public ICommand SetSaharificationMethodCommand { get; }
        public ICommand SetMashoutTemperatureCommand { get; }
        public ICommand SetMashoutTimeCommand { get; }
        public ICommand SetFilteringTemperatureCommand { get; }
        public ICommand SetFilteringTimeCommand { get; }
        public Device1ViewModel(IMasteraFactoryService masteraFactoryService, Device device, ushort currentGrindingTemperature, ushort currentGrindingTime, ushort currentGrindingMethod,
                ushort currentSaharificationTemperature, ushort currentSaharificationTime, ushort currentSaharificationMethod,
                ushort currentMashoutTemperature, ushort currentMashoutTime,
                ushort currentFilteringTemperature, ushort currentFilteringTime) {
            _device = device;
            _factoryService = masteraFactoryService;
            GrindingTemperatureIR = currentGrindingTemperature;
            GrindingTimeIR = currentGrindingTime;
            GrindingMethodIR = currentGrindingMethod;
            SaharificationMethodIR = currentSaharificationMethod;
            SaharificationTemperatureIR = currentSaharificationTemperature;
            SaharificationTimeIR = currentSaharificationTime;
            MashoutTemperatureIR = currentMashoutTemperature;
            MashoutTimeIR = currentMashoutTime;
            FilteringTemperatureIR = currentFilteringTemperature;
            FilteringTimeIR = currentFilteringTime;
            
            SetGrindingMethodCommand = new SetGrindingMethodCommand(_device, this);
            SetGrindingTimeCommand = new SetGrindingTimeCommand(_device, this);
            SetGrindingTemperatureCommand = new SetGrindingTemeperatureCommand(_device, this);
            
            SetSaharificationTemperatureCommand = new SetSaharificationTemperatureCommand(_device, this);
            SetSaharificationTimeCommand = new SetSaharificationTimeCommand(_device, this);
            SetSaharificationMethodCommand = new SetSaharificationMethodCommand(_device, this);

            SetMashoutTemperatureCommand = new SetMashoutTemperatureCommand(_device, this);
            SetMashoutTimeCommand = new SetMashoutTimeCommand(_device, this);

            SetFilteringTemperatureCommand = new SetFilteringTemperatureCommand(_device, this);
            SetFilteringTimeCommand = new SetFilteringTimeCommand(_device, this);
        }
    }
}
