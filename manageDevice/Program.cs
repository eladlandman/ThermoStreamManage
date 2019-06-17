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
        static void Main(string[] args)
        {
            
            ControlDevice myDevice = new ControlDevice();
            myDevice.ConnectToDevice();
            myDevice.TurnOnFlow();
            myDevice.SetAirFlowLimitValues(10, 25);
            myDevice.SetDesiredAirFlowRate(18);
            float _temp = myDevice.GetDesiredAirFlowRate();
            myDevice.TurnOffFlow();
            Console.ReadLine();
        }
    }
}
