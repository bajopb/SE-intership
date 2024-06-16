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
    /// <summary>
    /// Represents a device with various processing steps.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Unit ID of the device.
        /// </summary>
        public byte UnitId{ get; set; }
        /// <summary>
        /// IP address of the device.
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// Port number for the device connection.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Master service for Modbus operations.
        /// </summary>
        public IMasteraFactoryService Master { get;  set; }
        /// <summary>
        /// Grinding step for the device.
        /// </summary>
        public GrindingStep GrindingStep { get; set; }
        /// <summary>
        /// Saharification step for the device.
        /// </summary>
        public SaharificationStep SaharificationStep { get; set; }
        /// <summary>
        /// Mashout step for the device.
        /// </summary>
        public MashoutStep MashoutStep { get; set; }
        /// <summary>
        /// Filtering step for the device.
        /// </summary>
        public FilteringStep FilteringStep { get; set; }
        public Device(IMasteraFactoryService master, byte unitId, string ipAddress, int port) {
            UnitId = unitId;
            IPAddress = ipAddress;
            Port = port;
            Master = master;
        }
        /// <summary>
        /// Sets the registers for the grinding step.
        /// </summary>
        /// <param name="methodHoldingRegister">The holding register address for the method.</param>
        /// <param name="methodInputRegister">The input register address for the method.</param>
        /// <param name="temperatureHoldingRegister">The holding register address for the temperature.</param>
        /// <param name="temperatureInputRegister">The input register address for the temperature.</param>
        /// <param name="timeHoldingRegister">The holding register address for the time.</param>
        /// <param name="timeInputRegister">The input register address for the time.</param>
        public void SetRegistersForGrinding(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            GrindingStep=new GrindingStep(Master, UnitId, methodHoldingRegister, methodInputRegister, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        /// <summary>
        /// Sets the registers for the saharification step.
        /// </summary>
        /// <param name="methodHoldingRegister">The holding register address for the method.</param>
        /// <param name="methodInputRegister">The input register address for the method.</param>
        /// <param name="temperatureHoldingRegister">The holding register address for the temperature.</param>
        /// <param name="temperatureInputRegister">The input register address for the temperature.</param>
        /// <param name="timeHoldingRegister">The holding register address for the time.</param>
        /// <param name="timeInputRegister">The input register address for the time.</param>
        public void SetRegistersForSaharification(ushort methodHoldingRegister, ushort methodInputRegister, ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            SaharificationStep = new SaharificationStep(Master, UnitId, methodHoldingRegister, methodInputRegister, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        /// <summary>
        /// Sets the registers for the mashout step.
        /// </summary>
        /// <param name="temperatureHoldingRegister">The holding register address for the temperature.</param>
        /// <param name="temperatureInputRegister">The input register address for the temperature.</param>
        /// <param name="timeHoldingRegister">The holding register address for the time.</param>
        /// <param name="timeInputRegister">The input register address for the time.</param>
        public void SetRegistersForMashout(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            MashoutStep = new MashoutStep(Master, UnitId, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
        /// <summary>
        /// Sets the registers for the filtering step.
        /// </summary>
        /// <param name="temperatureHoldingRegister">The holding register address for the temperature.</param>
        /// <param name="temperatureInputRegister">The input register address for the temperature.</param>
        /// <param name="timeHoldingRegister">The holding register address for the time.</param>
        /// <param name="timeInputRegister">The input register address for the time.</param>
        public void SetRegistersForFiltering(ushort temperatureHoldingRegister, ushort tempreatureInputRegister,
            ushort timeHoldingRegister, ushort timeInputRegister)
        {
            FilteringStep = new FilteringStep(Master, UnitId, temperatureHoldingRegister, tempreatureInputRegister,
                timeHoldingRegister, timeInputRegister);
        }
    }
}
