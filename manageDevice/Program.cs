using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace manageDevice
{
    class Program
    {
        
        
        /*short test for checking temperature setting limits*/
        
        public static void TermoStreamFirstTest()
        {
            ControlDevice myDevice = new ControlDevice();
            myDevice.ConnectToDevice();
            myDevice.SetTemperatueLimitsForDevice(13, 29);
            float lower_limit = myDevice.GetLowAirTemperatureLimit();
            float higher_limit = myDevice.GetHighAirTemperatureLimit();
            float current_temp = myDevice.GetMainAirTemperatureFromDevice();
            Console.WriteLine($"low limit of temperature is :{lower_limit}");
            Console.WriteLine($"high limit of temperature is :{higher_limit}");
            Console.WriteLine($"main air temperature is : {current_temp}");
            myDevice.DisConnectFromDevice();
        }



        public static void TurnOnFlowTest()
        {
            ControlDevice myDevice = new ControlDevice();
            myDevice.ConnectToDevice();
            myDevice.TurnOnFlow();
        }



        public static float GetSelectesSetPointTempTest()
        {
            ControlDevice myDevice = new ControlDevice();
            myDevice.ConnectToDevice();
            myDevice.SetTemperatueLimitsForDevice(15, 28);
            myDevice.SetSelectedSetPointTemperature(22);
            float result = myDevice.GetCurrentSetPointTemperature();
            myDevice.DisConnectFromDevice();
            return result;

        }


        public static void ShowSelectedTempTest()
        {
            Console.WriteLine($"selected set temperature is : {GetSelectesSetPointTempTest()}");
        }





        
        static void Main(string[] args)
        {
            TermoStreamFirstTest();
            ShowSelectedTempTest();
            Console.ReadLine();
        }
    }
}
