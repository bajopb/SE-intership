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
    public class SetGrindingTimeCommand : CommandBase
    {
        private readonly Device _device;
        private readonly Device1ViewModel _device1ViewModel;
        public SetGrindingTimeCommand(Device device, Device1ViewModel viewModel)
        {
            _device = device;
            _device1ViewModel = viewModel;
            _device1ViewModel.PropertyChanged += OnViewModelPropertyChanded;
        }

        private void OnViewModelPropertyChanded(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_device1ViewModel.GrindingTimeHR))
            {
                OnCanExecutedChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return _device1ViewModel.GrindingTimeHR>0 && _device1ViewModel.GrindingTimeHR<180 && base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            _device.GrindingStep.Time.SetValue(_device1ViewModel.GrindingTimeHR);
        }
    }
}
