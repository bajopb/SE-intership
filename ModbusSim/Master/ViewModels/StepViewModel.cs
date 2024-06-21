using Backend.Models.Enums;
using Master.Models.SecondStageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.ViewModels
{
    public class StepViewModel:ViewModelBase
    {
        private StepType stepType;
        public ObservableCollection<ProcessViewModel> Processes { get; set; }
        public StepViewModel(StepType stepType, IStep step) {
            this.stepType = stepType;
            InitializeProcesses(step);
        }

        private void InitializeProcesses(IStep step)
        {
            Processes = new ObservableCollection<ProcessViewModel>();
            foreach(var item in step.Registers)
            {
                Processes.Add(new ProcessViewModel(item.Key, item.Value));
            }
        }

        #region Properties
        public StepType StepType
        {
            get
            {
                return stepType;
            }

            set
            {
                stepType = value;
                OnPropertyChanged("StepType");
            }
        }
        #endregion
    }
}
