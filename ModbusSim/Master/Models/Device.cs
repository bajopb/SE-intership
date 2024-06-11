using Master.Interfaces;
using Master.Models.SecondStageModels;
using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    internal class Device
    {
        public byte UnitId{ get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public IMasteraFactoryService Master { get; private set; }
        public GrindingStep GrindingStep { get; set; }
        public SaharificationStep SaharificationStep { get; set; }
        public MashoutStep MashoutStep { get; set; }
        public FilteringStep FilteringStep { get; set; }
        public Device(IMasteraFactoryService master, byte unitId, string ipAddress, int port) {
            UnitId = unitId;
            IPAddress = ipAddress;
            Port = port;
            Master = master;
        }

        public void SetRegistersForGrinding(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            GrindingStep=new GrindingStep(Master, UnitId, methodHoldingRegister, methodInputRegister, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        public void SetRegistersForSaharification(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            SaharificationStep = new SaharificationStep(Master, UnitId, methodHoldingRegister, methodInputRegister, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        public void SetRegistersForMashout(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            MashoutStep = new MashoutStep(Master, UnitId, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        public void SetRegistersForFiltering(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            FilteringStep = new FilteringStep(Master, UnitId, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
    }
}
