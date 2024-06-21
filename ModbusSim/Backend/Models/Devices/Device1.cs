using Backend.Interfaces;
using Backend.MasterServices;
using Backend.Models.Enums;
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
        public IMasterService MasterService {get; private set;}
        public byte UnitID { get; private set; }
        public Dictionary<StepType, IStep> Steps { get;  set; }
         //ovde Dict<step type, istep> dict, u step da ima isto recnik za procese i onda da se pristupa
         //dict[deviceid].steps[Saharification].process[temperature].holdingReg
        public Device1(IMasterService masterService, byte unitId, Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic) {
            MasterService = masterService;
            UnitID = unitId;
            SetSteps(dic);
        }
        private void SetSteps(Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic) {
            foreach(var item in dic)
            {
                if (item.Key == StepType.GRINDING_S)
                {
                    Steps.Add(StepType.GRINDING_S, new GrindingStep(this, item.Value));
                }
                else if (item.Key == StepType.SAHARIFICATION_S)
                {
                    Steps.Add(StepType.SAHARIFICATION_S, new SaharificationStep(this, item.Value));
                }
                else if (item.Key == StepType.MASHOUT_S)
                {
                    Steps.Add(StepType.MASHOUT_S, new MashoutStep(this, item.Value));
                }
                else if (item.Key == StepType.FILTERING_S)
                {
                    Steps.Add(StepType.FILTERING_S, new FilteringStep(this, item.Value));
                }
            }
        }
    }
}
