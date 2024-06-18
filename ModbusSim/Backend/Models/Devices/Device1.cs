using Backend.Interfaces;
using Backend.Models.ProcessSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Devices
{
    public class Device1 : IDevice
    {
        public int GlobalID { get; private set; }
        public IMasterFactoryService MasterFactory {get; private set;}
        public byte UnitID { get; private set; }
        public List<IStep> Steps { get; private set; }
        public Device1(int globalId, IMasterFactoryService masterFactoryService, byte unitId) {
            GlobalID = globalId;
            MasterFactory = masterFactoryService;
            UnitID = unitId;
        }
    }
}
