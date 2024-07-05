using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EventArgs
{
    /// <summary>
    /// Represents the event arguments for Slave data store changes.
    /// </summary>
    public class DataStoreChangedEventArgs : System.EventArgs
    {
        /// <summary>
        /// Gets the unit ID of the Slave where the data store change occurred.
        /// </summary>
        public byte UnitID { get; }

        /// <summary>
        /// Gets the starting address of the data store change.
        /// </summary>
        public ushort StartAddress { get; }

        /// <summary>
        /// Gets the number of points that were changed in the data store.
        /// </summary>
        public ushort NumberOfPoints { get; }

        public DataStoreChangedEventArgs(byte unitID, ushort startAddress, ushort numberOfPoints)
        {
            UnitID = unitID;
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }
    }
}
