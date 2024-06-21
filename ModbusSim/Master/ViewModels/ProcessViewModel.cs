using Backend.Models.Enums;
using Master.Models;
using Master.Models.SecondStageModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.ViewModels
{
    public class ProcessViewModel:ViewModelBase
    {
        private ProcessType processType;
        private ushort holdingRegister;
        private ushort inputRegister;
        public ProcessViewModel(ProcessType type, SetPoint setPoint) { 
            processType = type;
            holdingRegister = setPoint.HoldingRegister;
            inputRegister = setPoint.InputRegister;
        }

        #region Properties
        public ProcessType ProcessType
        {
            get
            {
                return processType;
            }

            set
            {
                processType = value;
                OnPropertyChanged("ProcessType");
            }
        }
        public ushort HoldingRegister
        {
            get
            {
                return holdingRegister;
            }

            set
            {
                holdingRegister = value;
                OnPropertyChanged("HoldingRegister");
            }
        }
        public ushort InputRegister
        {
            get
            {
                return inputRegister;
            }

            set
            {
                inputRegister = value;
                OnPropertyChanged("InputRegister");
            }
        }

        #endregion
    }
}
