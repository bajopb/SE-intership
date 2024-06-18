using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models.Enums;
using Backend.Models.ProcessSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Configuration
{
    public class ConfigItem : IConfigItem
    {
        public byte UnitID { get; private set; }

        public string Address { get; private set; }

        public int Port { get; private set; }

        public Dictionary<StepType, List<ushort>> Registers { get; private set; }

        public ConfigItem(List<string> configParameters)
        {
            UnitID = Convert.ToByte(configParameters[0]);
            Port = Convert.ToInt32(configParameters[1]);
            Address = Convert.ToString(configParameters[2]);
           Registers=GetRegisters(configParameters);
        }

        private Dictionary<StepType, List<ushort>> GetRegisters(List<string> configParameters)
        {
            Dictionary < StepType, List<ushort>> dic=new Dictionary<StepType, List<ushort>>();
            for (int i = 3; i < configParameters.Count; i++) { 
                string[] reg = configParameters[i].Split(' ');
                StepType st = GetStepType(reg[0]);
                List<ushort> addr = new List<ushort>();
                for (int j = 1; i < reg.Length; j++) {
                    addr.Add(Convert.ToUInt16(reg[j]));
                }
                dic.Add(st, addr);
            }
            return dic;
        }

        private StepType GetStepType(string stepType) {
            StepType st;
            switch (stepType)
            {
                case "GR_S":
                    st =StepType.GRINDING_S;
                    break;
                case "SA_S":
                    st = StepType.SAHARIFICATION_S;
                    break;
                case "MA_S":
                    st =StepType.MASHOUT_S;
                    break;
                case "FI_S":
                    st =StepType.FILTERING_S;
                    break;
                default:
                    throw new ConfigurationException("Invalid step name. Check configuration file.");
            }
            return st;
        }
    }
}
