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
            float _temp = myDevice.GetMainAirTemperatureFromDevice();
            myDevice.SetTemperatueForDevice(20, 30, 25);
            Console.ReadLine();
        }
    }
}
