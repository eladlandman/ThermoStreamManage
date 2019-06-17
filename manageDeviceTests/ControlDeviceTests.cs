using Microsoft.VisualStudio.TestTools.UnitTesting;
using manageDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manageDevice.Tests
{
    [TestClass()]
    public class ControlDeviceTests
    {
        [TestMethod()]
        public void ControlDeviceTest()
        {
          
        }

        [TestMethod()]
        public void ConnectToDeviceTest()
        {
            
        }



        [TestMethod()]
        public void GetLimitsAirTemperatureFromDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetAirFlowLimitValues(10, 25);
            float lowLimitTemperature = device.GetLowAirTemperatureLimit();
            Assert.AreEqual(lowLimitTemperature, 10);
            float highLimitTemperature = device.GetHighAirTemperatureLimit();
            Assert.AreEqual(highLimitTemperature, 25);
        }

      
        [TestMethod()]
        public void GetLimitsAirFlowRateInLitersTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.TurnOnFlow();
            device.SetAirFlowLimitValues(3, 10);
            float airFlowRateLowerLimit = device.GetLowAirFlowRateLimit();
            float airFlowRateHigherLimit = device.GetHighAirFlowRateLimit();
            device.TurnOffFlow();
            Assert.AreEqual(airFlowRateLowerLimit, 3);
            Assert.AreEqual(airFlowRateHigherLimit, 10);
        }

        [TestMethod()]
        public void GetMainTemperatueForDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            float currentTemp = device.GetMainAirTemperatureFromDevice();
            Assert.IsTrue(currentTemp >= device.GetLowAirTemperatureLimit());
            Assert.IsTrue(currentTemp <= device.GetHighAirTemperatureLimit());   
        }

        [TestMethod()]
        public void SetAirFlowValuesTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.TurnOnFlow();
            device.SetDesiredAirFlowRate(20);
            float desiret_temp = device.GetDesiredAirFlowRate();
            Assert.AreEqual(desiret_temp, 20);
        }

        [TestMethod()]
        public void GetPowerFromDeviceTest()
        {


           
        }

        [TestMethod()]
        public void SetPowerToDeviceTest()
        {


            
        }
    }
}