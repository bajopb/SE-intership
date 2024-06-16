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
    public class SetSaharificationTemperatureCommand:CommandBase
    {
        private readonly Device _device;
        private readonly Device1ViewModel _device1ViewModel;
        public SetSaharificationTemperatureCommand(Device device, Device1ViewModel viewModel)
        {
            _device = device;
            _device1ViewModel = viewModel;
            _device1ViewModel.PropertyChanged += OnViewModelPropertyChanded;
        }

        public override void Execute(object parameter)
        {
            _device.SaharificationStep.Temperature.SetValue(_device1ViewModel.SaharificationTemperatureHR);
            _device1ViewModel.SaharificationTemperatureHR = 0;
        }

        public override bool CanExecute(object parameter)
        {
            return _device1ViewModel.SaharificationTemperatureHR > 0 && _device1ViewModel.SaharificationTemperatureHR < 120 && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanded(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_device1ViewModel.SaharificationTemperatureHR))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
