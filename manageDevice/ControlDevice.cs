using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;



namespace manageDevice
{
    public class ControlDevice
    {

        private SerialPort _serialPort { get; set; }

        public ControlDevice()
        {
            _serialPort = new SerialPort("COM4");
        }

        public bool ConnectToDevice()
        {
            if (_serialPort != null && !_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
            return _serialPort.IsOpen;
        }

        public void DisConnectFromDevice()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }


        public void TurnOnFlow()
        {
            String command = "FLOW 1";
            SetOperationFunc(command);
        }

        public void TurnOffFlow()
        {
            String command = "FLOW 0";
            SetOperationFunc(command);
        }

   
        private bool SetOperationFunc(String command)
        {
            if (!(_serialPort.IsOpen))
            {
                _serialPort.Open();
            }
            try
            {
                _serialPort.WriteLine(command);
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("error occured");
                _serialPort.Close();
            }
            return false;
        }



        private float GetOperationFunc(String command)
        {
            float result = 0;
            if (!(_serialPort.IsOpen))
            {
                _serialPort.Open();
            }

            try
            {
                _serialPort.WriteLine(command);
                result = float.Parse(_serialPort.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured");
                _serialPort.Close();
            }
            return result;
        }

    
        public void SetAirFlowLimitValues(float lowlimit, float highlimit)
        {
            if (lowlimit >= 1 && lowlimit <= 5 && highlimit >= 5 && highlimit <= 20)
            {
                String _lowtemp = lowlimit.ToString(), _hightemp = highlimit.ToString();
                string command = "FLLE " + _lowtemp + ";FLUE " + _hightemp;
                SetOperationFunc(command);
            }
            else
            {
                Console.WriteLine("You gave parameters out of expected range");
            }
        }

        public void SetDesiredAirFlowRate(float _rate)
        {
            if (_rate >= 5 && _rate <= 18)
            {
                String rate = _rate.ToString();
                String command = "FLSE" + " rate";
                SetOperationFunc(command);
            }
            else
            {
                Console.WriteLine("you gave rate not in expected range");
            }
        }


        public float GetDesiredAirFlowRate()
        {
            String command = "FLWM?";
            return GetOperationFunc(command);
        }


        public float GetMeasuredAirFlowRate()
        {
            String command = "FLWR?";
            return GetOperationFunc(command);
        }

        public float GetLowAirFlowRateLimit()
        {
            return GetOperationFunc("FLLE?");
        }

        public float GetHighAirFlowRateLimit()
        {
            return GetOperationFunc("FLUE?");
        }



        public void SetTemperatueLimitsForDevice(float lowtemp, float hightemp)
        {
            if (lowtemp >= -150 && lowtemp <= 25 && hightemp >= 25 && hightemp <= 225)
            {
                String _lowtemp = lowtemp.ToString(), _hightemp = hightemp.ToString();
                string command = "LLIM " + _lowtemp + ";ULIM " + _hightemp;
                SetOperationFunc(command);
            }
            else
            {
                Console.WriteLine("You gave parameters out of expected range");
            }
        }


        public void SetSelectedSetPointTemperature(float _rate)
        {
            if (_rate >= -99.9 && _rate <= 225 && TempInRange(_rate))
            {
                String rate = _rate.ToString();
                String command = "SETP " + _rate;
                SetOperationFunc(command);
            }
            else
            {
                Console.WriteLine("you gave rate not in expected range");
            }
        }

        public float GetMainAirTemperatureFromDevice()
        {
            return GetOperationFunc("TEMP?");
        }


        public float GetCurrentTemperatureSetPoint()
        {
            return GetOperationFunc("SETP?");
        }



        public float GetLowAirTemperatureLimit()
        {
            return GetOperationFunc("LLIM?");
        }

        public float GetHighAirTemperatureLimit()
        {
            return GetOperationFunc("ULIM?");
        }

        private bool TempInRange(float temp)
        {
            return (temp >= GetLowAirTemperatureLimit() && temp <= GetHighAirTemperatureLimit());
        }

        /*
        public void SetHighTemperatureValue(float highlimit)
        {
            String _highTemp = highlimit.ToString();
            String command = "ULIM" + _highTemp;
            SetOperationFunc(command);
        }


        public void SetLowTemperatureValue(float lowlimit)
        {
            String _lowTemp = lowlimit.ToString();
            String command = "LLIM" + _lowTemp;
            SetOperationFunc(command);
        }

        private static Decimal ConvertStringToNumber(String str)
        {
            return Convert.ToDecimal(str);
        }


        private static String ConvertDecimalToString(Decimal num)
        {
            return "";
        }
        */


    }
}
