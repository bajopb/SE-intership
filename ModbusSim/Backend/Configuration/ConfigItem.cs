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
    /// <summary>
    /// Represents a implementation of <see cref="IConfigItem"/>.
    /// </summary>
    public class ConfigItem : IConfigItem
    {
        private delegate Dictionary<ProcessType, List<ushort>> Loader(string[] reg);
        private static readonly Dictionary<StepType, Loader> loader = new Dictionary<StepType, Loader>
        {
            {StepType.GRINDING_S, LoadTemperatureTimeAndMethod },
            {StepType.SAHARIFICATION_S, LoadTemperatureTimeAndMethod },
            {StepType.MASHOUT_S, LoadTemperatureAndTime },
            {StepType.FILTERING_S, LoadTemperatureAndTime }
        };
        private static readonly Dictionary<string, StepType> mappings = new Dictionary<string, StepType>
        {
            {"GR_S", StepType.GRINDING_S },
            {"SA_S", StepType.SAHARIFICATION_S },
            {"MA_S", StepType.MASHOUT_S },
            {"FI_S", StepType.FILTERING_S }
        };
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
            for (int i = 1; i < configParameters.Count; i++)
            { 
                string[] reg = configParameters[i].Split(' ');
                StepType st;
                if (!mappings.TryGetValue(reg[0], out st))
                {
                    throw new ConfigurationException("Incorrect Step Type value.");
                }
                Loader strategy;
                if(!loader.TryGetValue(st, out strategy))
                {
                    throw new ConfigurationException();
                }
                dic.Add(st, strategy(reg));
            }
            return dic;
        }

        private static Dictionary<ProcessType, List<ushort>> LoadTemperatureAndTime(string[] reg)
        {
            Dictionary<ProcessType, List<ushort>> dic = new Dictionary<ProcessType, List<ushort>>();
            dic.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
            dic.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
            return dic;
        }

        private static Dictionary<ProcessType, List<ushort>> LoadTemperatureTimeAndMethod(string[] reg)
        {
            Dictionary<ProcessType, List<ushort>> dic = new Dictionary<ProcessType, List<ushort>>();
            dic.Add(ProcessType.TEMPERATURE, new List<ushort> { ushort.Parse(reg[1]), ushort.Parse(reg[2]) });
            dic.Add(ProcessType.TIME, new List<ushort> { ushort.Parse(reg[3]), ushort.Parse(reg[4]) });
            dic.Add(ProcessType.METHOD, new List<ushort> { ushort.Parse(reg[5]), ushort.Parse(reg[6]) });
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
