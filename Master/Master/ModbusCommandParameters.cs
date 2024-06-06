using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    public abstract class ModbusCommandParameters
    {
        public ushort TransactionID { get; set; }
        public ushort ProtocolID { get; set; }
        public ushort Length { get; set; }
        public byte UnitID { get; set; }
        public byte FunctionCode { get; set; }


        public ModbusCommandParameters(ushort transactionID, ushort length, byte unitID, byte functionCode) {
            TransactionID = transactionID;
            ProtocolID = 0;
            Length = length;
            UnitID = unitID;
            FunctionCode = functionCode;
        }

    }
}
