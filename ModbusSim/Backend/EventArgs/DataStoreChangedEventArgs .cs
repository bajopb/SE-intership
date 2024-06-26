using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.EventArgs
{
    public class DataStoreChangedEventArgs : System.EventArgs
    {
        public byte UnitID { get; }
        public ushort StartAddress { get; }
        public ushort NumberOfPoints { get; }

        public DataStoreChangedEventArgs(byte unitID, ushort startAddress, ushort numberOfPoints)
        {
            UnitID = unitID;
            StartAddress = startAddress;
            NumberOfPoints = numberOfPoints;
        }
    }
}
