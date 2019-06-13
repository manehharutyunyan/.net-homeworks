using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServer
{
    public class MathService : IMathService
    {
        public double Add(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }

        public double Div(double firstValue, double secondValue)
        {
            return firstValue / secondValue;
        }

        public double Mult(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }

        public double Sub(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }

        // A method which will do appropriate operations based on the incoming request
        public double PerformOperation(string operation)
        {
            string[] data = operation.Split(':');
            double result = 0;
            switch (data[0])
            {
                case "+":
                    result = Add(Convert.ToDouble(data[1]), Convert.ToDouble(data[2]));
                    break;
                case "-":
                    result = Sub(Convert.ToDouble(data[1]), Convert.ToDouble(data[2]));
                    break;
                case "/":
                    result = Div(Convert.ToDouble(data[1]), Convert.ToDouble(data[2]));
                    break;
                case "*":
                    result = Mult(Convert.ToDouble(data[1]), Convert.ToDouble(data[2]));
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
