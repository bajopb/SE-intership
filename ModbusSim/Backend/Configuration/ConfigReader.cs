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
    /// <summary>
    /// Reads configuration from a text file and implements <see cref="IConfiguration"/>.
    /// </summary>
    public class ConfigReader : IConfiguration
    {
        private string path = "C:\\Users\\nikola\\Desktop\\SE-intership\\SE-intership\\ModbusSim\\Backend\\RtuCfg.txt";
        private byte deviceCounter=1;
        private Dictionary<byte, IConfigItem> devicesToConfiguration = new Dictionary<byte, IConfigItem>();
        private ConfigItemEqualityComparer equalityComparer = new ConfigItemEqualityComparer();
        public string Address { get; private set; }
        public int Port { get; private set; }
        public ConfigReader() {
            ReadConfiguration();
        }
        /// <summary>
        /// Retrieves the list of configuration items.
        /// </summary>
        /// <returns>A list of <see cref="IConfigItem"/> representing the configuration items.</returns>
        public List<IConfigItem> GetConfigurationItems()
        {
            return new List<IConfigItem>(devicesToConfiguration.Values);
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
    }
}
