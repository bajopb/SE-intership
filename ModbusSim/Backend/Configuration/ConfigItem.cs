using Backend.Exceptions;
using Backend.Interfaces;
using Backend.Models.Enums;
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
        public Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> Registers { get; private set; }

        public ConfigItem(List<string> configParameters)
        {
           UnitID = Convert.ToByte(configParameters[0].Split(' ')[1]);
           Registers=GetRegisters(configParameters);
        }

        private Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> GetRegisters(List<string> configParameters)
        {
            Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> dic = new Dictionary<StepType, Dictionary<ProcessType, List<ushort>>>();
            for (int i = 1; i < configParameters.Count; i++) { 
                string[] reg = configParameters[i].Split(' ');
                StepType st = GetStepType(reg[0]);
                Dictionary<StepType, Dictionary<ProcessType, List<ushort>>> addr = new Dictionary<StepType, Dictionary<ProcessType, List<ushort>>>();
                if (st==StepType.GRINDING_S)
                {
                    Dictionary < ProcessType, List<ushort>> addrs=new Dictionary<ProcessType, List<ushort>>();
                    addrs.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
                    addrs.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
                    addrs.Add(ProcessType.METHOD, new List<ushort> { ushort.Parse(reg[5]), ushort.Parse(reg[6]) });
                    dic.Add(st, addrs);
                }
                if (st == StepType.SAHARIFICATION_S)
                {
                    Dictionary<ProcessType, List<ushort>> addrs = new Dictionary<ProcessType, List<ushort>>();
                    addrs.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
                    addrs.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
                    addrs.Add(ProcessType.METHOD, new List<ushort> { ushort.Parse(reg[5]), ushort.Parse(reg[6]) });
                    dic.Add(st, addrs);
                }
                if (st == StepType.MASHOUT_S)
                {
                    Dictionary<ProcessType, List<ushort>> addrs = new Dictionary<ProcessType, List<ushort>>();
                    addrs.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
                    addrs.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
                    dic.Add(st, addrs);
                }
                if (st == StepType.FILTERING_S)
                {
                    Dictionary<ProcessType, List<ushort>> addrs = new Dictionary<ProcessType, List<ushort>>();
                    addrs.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
                    addrs.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
                    dic.Add(st, addrs);
                }
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
