using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IConfiguration
    {
        string Address { get;}
        int Port { get;}    
        List<IConfigItem> GetConfigurationItems();
    }
}
