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
        public void GetMainAirTemperatureFromDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetTemperatueForDevice(10, 30, 20);
            float setPointTemperature = device.GetSetPointTemperature();
            Assert.AreEqual(setPointTemperature, 20);
            float lowLimitTemperature = device.GetLowAirTemperatureLimit();
            Assert.AreEqual(lowLimitTemperature, 10);
            float highLimitTemperature = device.GetHighAirTemperatureLimit();
            Assert.AreEqual(highLimitTemperature, 30);

        }

        [TestMethod()]
        public void GetLowAirTemperatureLimitTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetLowTemperatureValue(12);
            float lowTemp = device.GetLowAirTemperatureLimit();
            Assert.AreEqual(lowTemp, 12);

        }

        [TestMethod()]
        public void GetAirFlowRateInLitersTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetAirFlowValues(10, 30, 40);
            float airFlowRate = device.GetAirFlowRate();
            Assert.AreEqual(airFlowRate, 40);
        }

        [TestMethod()]
        public void SetTemperatueForDeviceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetAirFlowValuesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPowerFromDeviceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetPowerToDeviceTest()
        {
            Assert.Fail();
        }
    }
}