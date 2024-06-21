using Backend.CommandExecutor;
using Backend.Models.Enums;
using Master.Interfaces;
using Master.Models;
using Master.Models.SecondStageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Master.ViewModels
{
    public class Device1ViewModel:ViewModelBase
    {
        private readonly Device _device;
        private byte unitId;
        public ObservableCollection<StepViewModel> StepViewModels {  get; set; }
        public Device1ViewModel(Device device, CommandExecutor commandExecutor) {
            _device = device;
            unitId = _device.UnitId;
            InitializeSteps(device.Steps);
        }
        private void InitializeSteps(Dictionary<StepType, IStep> steps) {
            StepViewModels = new ObservableCollection<StepViewModel>();
            foreach (var step in steps)
            {
                StepViewModels.Add(new StepViewModel(step.Key, step.Value));
            }
        }

        #region Properties
        public byte UnitId
        {
            get
            {
                return unitId;
            }

            set
            {
                unitId = value;
                OnPropertyChanged("UnitId");
            }
        }
        #endregion

    }
}
