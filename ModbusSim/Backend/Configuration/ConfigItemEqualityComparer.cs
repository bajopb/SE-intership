using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Configuration
{
    /// <summary>
    /// Provides methods to compare instances of <see cref="ConfigItem"/>.
    /// </summary>
    internal class ConfigItemEqualityComparer : IEqualityComparer<ConfigItem>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <see cref="ConfigItem"/> to compare.</param>
        /// <param name="y">The second object of type <see cref="ConfigItem"/> to compare.</param>
        /// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when device IDs are not unique.</exception>
        public bool Equals(ConfigItem x, ConfigItem y)
        {
            if (x.UnitID == y.UnitID) {
                throw new ArgumentException("Device ID must be unique. Check configuration file.");
            }
            return false;
        }
        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="ConfigItem"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode([DisallowNull] ConfigItem obj)
        {
            return base.GetHashCode();
        }
    }
}
