using Master.Interfaces;
using Master.Models;
using Master.ViewModels;
using Master.Views.DevicesViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Commands
{
    public class ShowDevice : CommandBase
    {
        private IMasteraFactoryService _masteraFactoryService;
        private Device _device;
        public ShowDevice(IMasteraFactoryService masteraFactoryService, Device device) { 
            _device = device;
            _masteraFactoryService = masteraFactoryService;
        }
        public async override void Execute(object parameter)
        {
            Device1View device1View = new Device1View()
            {
                DataContext = new Device1ViewModel(_masteraFactoryService, _device, await _device.GrindingStep.Temperature.GetProcessValue(),
                await _device.GrindingStep.Time.GetProcessValue(), await _device.GrindingStep.GrindingMethod.GetProcessValue(),
                await _device.SaharificationStep.Temperature.GetProcessValue(), await _device.SaharificationStep.Time.GetProcessValue(),
                await _device.SaharificationStep.Method.GetProcessValue(), await _device.MashoutStep.Temperature.GetProcessValue(),
                await _device.MashoutStep.Time.GetProcessValue(), await _device.FilteringStep.Temperature.GetProcessValue(),
                await _device.FilteringStep.Time.GetProcessValue()
                ) { }
            };
            device1View.Show();
        }

       
    }
}
