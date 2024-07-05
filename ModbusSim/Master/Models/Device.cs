using Backend.Models.Enums;
using Master.Models.SecondStageModels;
using Microsoft.Win32;
using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    /// <summary>
    /// Represents a device with various processing steps.
    /// </summary>
    public class Device:INotifyPropertyChanged
    { 
        private Dictionary<StepType, IStep> _steps;
        /// <summary>
        /// Gets or sets the dictionary of processing steps.
        /// </summary>
        public Dictionary<StepType, IStep> Steps
        {
            get => _steps;
            private set
            {
                _steps=value;
                OnPropertyChanged(nameof(Steps));
            }
        }
        /// <summary>
        /// Gets or sets the unit ID of the device.
        /// </summary>
        public byte UnitId { get; set; }
        public Device(byte unitId, Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic) {
            UnitId = unitId;
            Steps = new Dictionary<StepType, IStep>();
            SetSteps(dic);
        }

        /// <summary>
        /// Sets the value of a register.
        /// </summary>
        /// <param name="address">The address of the register.</param>
        /// <param name="value">The value to set.</param>
        public void SetRegisterValue(ushort address, ushort value)
        {
            foreach(var step in Steps)
            {
                foreach(var process in Steps.Values)
                {
                    foreach(var setPoint in process.Registers)
                    {
                        if (setPoint.Value.HoldingRegisterAddress == address)
                        {
                            setPoint.Value.HoldingRegisterValue = value;
                            OnPropertyChanged(nameof(Steps));
                        }
                        if (setPoint.Value.InputRegisterAddress == address)
                        {
                            setPoint.Value.InputRegisterValue = value;
                            OnPropertyChanged(nameof(Steps));
                        }
                    }
                }
            }
        }
        private void SetSteps(Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic)
        {
            foreach (var item in dic)
            {
                if (item.Key == StepType.GRINDING_S)
                {
                    Steps.Add(StepType.GRINDING_S, new GrindingStep(UnitId, StepType.GRINDING_S, item.Value));
                }
                else if (item.Key == StepType.SAHARIFICATION_S)
                {
                    Steps.Add(StepType.SAHARIFICATION_S, new SaharificationStep(UnitId, StepType.SAHARIFICATION_S, item.Value));
                }
                else if (item.Key == StepType.MASHOUT_S)
                {
                    Steps.Add(StepType.MASHOUT_S, new MashoutStep(UnitId, StepType.MASHOUT_S, item.Value));
                }
                else if (item.Key == StepType.FILTERING_S)
                {
                    Steps.Add(StepType.FILTERING_S, new FilteringStep(UnitId, StepType.FILTERING_S, item.Value));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
