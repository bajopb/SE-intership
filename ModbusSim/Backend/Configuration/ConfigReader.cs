using Backend.Exceptions;
using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using Backend.Models.Enums;

namespace Backend.Configuration
{
    public class ConfigReader : IConfiguration
    {
        private string path = "RtuCfg.txt";
        private int deviceCounter=1;
        private Dictionary<byte, IConfigItem> devicesToConfiguration = new Dictionary<byte, IConfigItem>();
        private ConfigItemEqualityComparer equalityComparer = new ConfigItemEqualityComparer();
        public ConfigReader() {
            ReadConfiguration();
        }

        private void ReadConfiguration() {
            using (TextReader tr = new StreamReader(path))
            {
                string config = tr.ReadToEnd();
                string[] splitedDevices = config.Split("//");
                for (int i = 0; i < splitedDevices.Length; i++)
                {
                    string[] splitedParameters = splitedDevices[i].Split("\n");
                    for (int j = 0; i < splitedParameters.Length; j++)
                    {
                        List<string> filtered = splitedParameters.ToList().FindAll(x => !string.IsNullOrEmpty(x));
                        try
                        {
                            ConfigItem ci = new ConfigItem(filtered);
                            if (devicesToConfiguration.Count > 0)
                            {
                                foreach (ConfigItem cf in devicesToConfiguration.Values)
                                {
                                    if (!equalityComparer.Equals(cf, ci))
                                    {
                                        devicesToConfiguration.Add(ci.UnitID, ci);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                devicesToConfiguration.Add(ci.UnitID, ci);
                            }
                        }
                        catch (ArgumentException argEx)
                        {
                            throw new ConfigurationException($"Configuration error: {argEx.Message}", argEx);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            if (devicesToConfiguration.Count == 0)
            {
                throw new ConfigurationException("Configuration error! Check RtuCfg.txt file!");
            }
        }
        public List<IConfigItem> GetConfigurationItems()
        {
            return new List<IConfigItem>(devicesToConfiguration.Values);
        }
    }
}
