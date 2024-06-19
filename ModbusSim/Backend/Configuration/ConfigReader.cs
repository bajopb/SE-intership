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
        private string path = "C:\\Users\\Perun\\Desktop\\New folder\\SE-intership\\ModbusSim\\Master\\RtuCfg.txt";
        private byte deviceCounter=1;
        public string Address { get; private set; }
        public int Port { get; private set; }
        private Dictionary<byte, IConfigItem> devicesToConfiguration = new Dictionary<byte, IConfigItem>();
        private ConfigItemEqualityComparer equalityComparer = new ConfigItemEqualityComparer();
        public ConfigReader() {
            ReadConfiguration();
        }

        private void ReadConfiguration() {
            using (TextReader tr = new StreamReader(path))
            {
                string config=tr.ReadToEnd();
                Console.WriteLine(config);
                string[] devicesSplited=config.Split(';');
                string[] addressPort = devicesSplited[0].Split("\r\n");
                Port = Convert.ToInt32(addressPort[0].Split(' ')[1]);
                Address = Convert.ToString(addressPort[1].Split(' ')[1]);
                for(int i = 1; i < devicesSplited.Length; i++)
                {
                    List<string> filtered = devicesSplited[i].Split("\r\n").ToList().FindAll(t=>!string.IsNullOrEmpty(t));
                    ConfigItem ci = new ConfigItem(filtered);
                    if (devicesToConfiguration.Count > 0)
                    {
                        foreach (ConfigItem cf in devicesToConfiguration.Values)
                        {
                            if (!equalityComparer.Equals(cf, ci))
                            {
                                devicesToConfiguration.Add(deviceCounter, ci);
                                deviceCounter++;
                            }
                        }
                    }
                    else {
                        devicesToConfiguration.Add(deviceCounter, ci);
                        deviceCounter++;
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
