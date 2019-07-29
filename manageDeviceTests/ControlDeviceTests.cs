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
        public void ConnectToDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            Assert.IsTrue(device.ConnectToDevice());
            device.DisConnectFromDevice();
        }



        [TestMethod()]
        public void GetLimitsAirTemperatureFromDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetTemperatueLimitsForDevice(17, 29);
            float lowLimitTemperature = device.GetLowAirTemperatureLimit();
            Assert.AreEqual(lowLimitTemperature, 17);
            float highLimitTemperature = device.GetHighAirTemperatureLimit();
            Assert.AreEqual(highLimitTemperature, 29);
            device.DisConnectFromDevice();
        }


       
       
        [TestMethod()]
        public void GetMainTemperatueForDeviceTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetTemperatueLimitsForDevice(10, 28);
            float currentTemp = device.GetMainAirTemperatureFromDevice();
            Assert.IsTrue(currentTemp >= 10 && currentTemp <= 28);
            device.DisConnectFromDevice();
        }



        [TestMethod()]
        public void TurnOnFlowTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.TurnOnFlow();
        }




        [TestMethod()]
        public void TurnOffFlowTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.TurnOnFlow();
            device.TurnOffFlow();
            
        }



        /* might be not supported by 505 manual
        [TestMethod()]
        public void GetLimitsAirFlowRateInLitersTest()
        {
            ControlDevice device = new ControlDevice();
            device.ConnectToDevice();
            device.SetAirFlowLimitValues(1, 5);
            float airFlowRateLowerLimit = device.GetLowAirFlowRateLimit();
            float airFlowRateHigherLimit = device.GetHighAirFlowRateLimit();
            Assert.AreEqual(airFlowRateLowerLimit, 1);
            Assert.AreEqual(airFlowRateHigherLimit, 5);
            device.DisConnectFromDevice();
        }
        */

        /* might be not supported by 505 manual
    [TestMethod()]
    public void SetAirFlowValuesTest()
    {
        ControlDevice device = new ControlDevice();
        device.ConnectToDevice();
        device.SetAirFlowLimitValues(3, 10);
        device.SetDesiredAirFlowRate(8);
        float desiret_temp = device.GetDesiredAirFlowRate();
        Assert.AreEqual(desiret_temp, 8);
        device.DisConnectFromDevice();
    }
    */

        /*

        [TestMethod()]
        public void GetPowerFromDeviceTest()
        {

        }

        [TestMethod()]
        public void SetPowerToDeviceTest()
        {



        }

        [TestMethod()]
        public void ControlDeviceTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ConnectToDeviceTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisConnectFromDeviceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TurnOnFlowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TurnOffFlowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetAirFlowLimitValuesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDesiredAirFlowRateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDesiredAirFlowRateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMeasuredAirFlowRateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLowAirFlowRateLimitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHighAirFlowRateLimitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTemperatueLimitsForDeviceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetSelectedSetPointTemperatureTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMainAirTemperatureFromDeviceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCurrentTemperatureSetPointTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLowAirTemperatureLimitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHighAirTemperatureLimitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDynamicTemperatureSetPointTest()
        {
            Assert.Fail();
        }
        */
    }
}