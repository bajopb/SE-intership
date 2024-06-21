using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Configuration
{
    internal class ConfigItemEqualityComparer : IEqualityComparer<ConfigItem>
    {
        public bool Equals(ConfigItem x, ConfigItem y)
        {
            if (x.UnitID == y.UnitID) {
                throw new ArgumentException("Device ID must be unique. Check configuration file.");
            }
            //foreach (var item in x.Registers) {
            //    foreach (ushort reg in item.Value) {
            //        foreach (var item2 in y.Registers) {
            //            if (item2.Value.Contains(reg)) {
            //                throw new ArgumentException("Register address must be unique. Check configuration file.");
            //            }
            //        }
            //    }
            //}
            return false;
        }

        public int GetHashCode([DisallowNull] ConfigItem obj)
        {
            return base.GetHashCode();
        }
    }
}
