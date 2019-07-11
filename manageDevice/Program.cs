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
            myDevice.SetTemperatueLimitsForDevice(2, 29);
            float lower_limit = myDevice.GetLowAirTemperatureLimit();
            float higher_limit = myDevice.GetHighAirTemperatureLimit();
            float current_temp = myDevice.GetMainAirTemperatureFromDevice();
            Console.WriteLine($"low limit of temperature is :{lower_limit}");
            Console.WriteLine($"high limit of temperature is :{higher_limit}");
            Console.WriteLine($"main air temperature is : {current_temp}");
            myDevice.TurnOffFlow();
            myDevice.DisConnectFromDevice();
        }






        /*checking airflow setting limits
        public void TermoStreamSecondTest()
        {
            ControlDevice myDevice = new ControlDevice();
            myDevice.ConnectToDevice();
            myDevice.TurnOnFlow();
            myDevice.SetAirFlowLimitValues(10, 25);
            myDevice.SetDesiredAirFlowRate(18);
            float _temp = myDevice.GetDesiredAirFlowRate();
            Console.WriteLine($"the desired temperature we got is: {_temp}");
            myDevice.TurnOffFlow();
            myDevice.DisConnectFromDevice();

        }


    */

    

     
    






        static void Main(string[] args)
        {
            TermoStreamFirstTest();
            Console.ReadLine();
        }
    }
}
