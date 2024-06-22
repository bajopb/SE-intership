using Backend.Models.Enums;
using Master.Models.SecondStageModels;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    /// <summary>
    /// Represents a device with various processing steps.
    /// </summary>
    public class Device
    { 
        public byte UnitId { get;set; }
        /// <summary>
        /// Grinding step for the device.
        /// </summary>
        public Dictionary<StepType, IStep> Steps { get; set; }
        public Device(byte unitId, Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic) {
            UnitId = unitId;
            Steps = new Dictionary<StepType, IStep>();
            SetSteps(dic);
        }
        private void SetSteps(Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic)
        {
            foreach (var item in dic)
            {
                if (item.Key == StepType.GRINDING_S)
                {
                    Steps.Add(StepType.GRINDING_S, new GrindingStep(UnitId, StepType.GRINDING_S, item.Value));
                }
                else if (item.Key == StepType.SAHARIFICATION_S)
                {
                    Steps.Add(StepType.SAHARIFICATION_S, new SaharificationStep(UnitId, StepType.SAHARIFICATION_S, item.Value));
                }
                else if (item.Key == StepType.MASHOUT_S)
                {
                    Steps.Add(StepType.MASHOUT_S, new MashoutStep(UnitId, StepType.MASHOUT_S, item.Value));
                }
                else if (item.Key == StepType.FILTERING_S)
                {
                    Steps.Add(StepType.FILTERING_S, new FilteringStep(UnitId, StepType.FILTERING_S, item.Value));
                }
            }
        }
    }
}
