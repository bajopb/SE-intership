using Master.Interfaces;
using Master.Models;
using Master.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Commands.SetterCommands
{
    public class SetGrindingMethodCommand:CommandBase
    {
        private readonly Device _device;
        private readonly Device1ViewModel _device1ViewModel;
        public SetGrindingMethodCommand(Device device, Device1ViewModel viewModel) {
            _device = device;
            _device1ViewModel = viewModel;
            _device1ViewModel.PropertyChanged += OnViewModelPropertyChanded;
        }

        private void OnViewModelPropertyChanded(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_device1ViewModel.GrindingMethodHR)) { 
                OnCanExecutedChanged();
            }
        }

        public  override void Execute(object parameter)
        {
            _device.GrindingStep.GrindingMethod.SetValue(_device1ViewModel.GrindingMethodHR);
            _device1ViewModel.GrindingMethodHR = 0;
        }
        public override bool CanExecute(object parameter)
        {
            return _device1ViewModel.GrindingMethodHR<16 && _device1ViewModel.GrindingMethodHR>0 && base.CanExecute(parameter);
        }
    }
}
