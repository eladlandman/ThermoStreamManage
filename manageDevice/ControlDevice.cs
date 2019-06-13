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

        public void SetDesiredAirFlowRate(float _rate)
        {
            if (_rate >= 5 && _rate <= 18)
            {
                String rate = _rate.ToString();
                String command = "FLUE" + " rate";
                SetOperationFunc(command);
            }
            else
            {
                Console.WriteLine("you gave rate not in expected range");
            }
        }

        public float GetDesiredAirFlowRate()
        {

            String command = "FLWM ?";
            return GetOperationFunc(command);
        }


        public float GetMeasuredAirFlowRate()
        {
            String command = "FLWR ?";
            return GetOperationFunc(command);
        }



        public float GetMainAirTemperatureFromDevice()
        {
            return GetOperationFunc("TEMP?");
        }


        public float GetLowAirTemperatureLimit()
        {
            return GetOperationFunc("LLIM?");
        }

        public float GetHighAirTemperatureLimit()
        {
            return GetOperationFunc("ULIM?");
        }


        public float GetAirFlowRate()
        {
            return GetOperationFunc("FLSE?");
        }



        public void SetTemperatueForDevice(float lowtemp,float hightemp,float setpoint)
        {
            String _lowtemp = lowtemp.ToString(), _hightemp = hightemp.ToString(), _setpoint = setpoint.ToString();
            string command = "LLIM"+ _lowtemp +";ULIM" +_hightemp +";SETP"+_setpoint;
            SetOperationFunc(command);
        }




        public void SetAirFlowValues(float lowlimit, float highlimit, float mainflow)
        {
            String _lowtemp = lowlimit.ToString(), _hightemp = highlimit.ToString(), _setpoint = mainflow.ToString();
            string command = "FLLE" + _lowtemp + ";FLUE" + _hightemp + ";FLSE" + _setpoint;
            SetOperationFunc(command);
        }



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



        public float GetSetPointTemperature()
        {
            return GetOperationFunc("SETP?");
        }




        public void SetPowerToDevice(Decimal power) { }


        private static Decimal ConvertStringToNumber(String str)
        {
            return Convert.ToDecimal(str);
        }


        private static String ConvertDecimalToString(Decimal num)
        {
            return "";
        }


    }
}
