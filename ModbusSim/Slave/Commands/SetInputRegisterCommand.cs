using Slave.Models;
using Slave.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Slave.Commands
{
    public class SetInputRegisterCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private Device _device;
        public SetInputRegisterCommand(Device device, MainViewModel mainView)
        {
            _device = device;
            _mainViewModel = mainView;
        }
        public override void Execute(object parameter)
        {
            int param = int.Parse(parameter.ToString());
            switch (param)
            {
                case 30001:
                    _device.GrindingMethodRegisters.WriteInputRegister(_mainViewModel.GrindingMethodIR);
                    break;
                case 30002:
                    _device.GrindingTemperatureRegisters.WriteInputRegister(_mainViewModel.GrindingTemperatureIR);
                    break;
                case 30003:
                    _device.GrindingTimeRegisters.WriteInputRegister(_mainViewModel.GrindingTimeIR);
                    break;
                case 30004:
                    _device.SaharificationMethodRegisters.WriteInputRegister(_mainViewModel.SaharificationMethodIR);
                    break;
                case 30005:
                    _device.SaharificationTemperatureRegisters.WriteInputRegister(_mainViewModel.SaharificationTemperatureIR);
                    break;
                case 30006:
                    _device.SaharificationTimeRegisters.WriteInputRegister(_mainViewModel.SaharificationTimeIR);
                    break;
                case 30007:
                    _device.MashoutTemperatureRegisters.WriteInputRegister(_mainViewModel.MashoutTemperatureIR);
                    break;
                case 30008:
                    _device.MashoutTimeRegisters.WriteInputRegister(_mainViewModel.MashoutTimeIR);
                    break;
                case 30009:
                    _device.FilteringTemperatureRegisters.WriteInputRegister(_mainViewModel.FilteringTemperatureIR);
                    break;
                case 30010:
                    _device.FilteringTimeRegisters.WriteInputRegister(_mainViewModel.FilteringTimeIR);
                    break;
            }
        }
        
    }
}
