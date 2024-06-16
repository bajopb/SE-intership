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
    public class SetMashoutTimeCommand : CommandBase
    {
        private readonly Device _device;
        private readonly Device1ViewModel _device1ViewModel;
        public SetMashoutTimeCommand(Device device, Device1ViewModel viewModel)
        {
            _device = device;
            _device1ViewModel = viewModel;
            _device1ViewModel.PropertyChanged += OnViewModelPropertyChanded;
        }

        public override void Execute(object parameter)
        {
            _device.MashoutStep.Time.SetValue(_device1ViewModel.MashoutTimeHR);
            _device1ViewModel.MashoutTimeHR = 0;
        }

        public override bool CanExecute(object parameter)
        {
            return _device1ViewModel.MashoutTimeHR > 0 && _device1ViewModel.MashoutTimeHR < 180 && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanded(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_device1ViewModel.MashoutTimeHR))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
