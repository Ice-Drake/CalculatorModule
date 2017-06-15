using System;

namespace PluginSDK
{
    public class RealNumber : Expression, Numeral
    {
        private double value;

        public string TypeName { get; private set; }

        public RealNumber(double value)
        {
            TypeName = "Real Number";
            this.value = value;
        }

        public Numeral evaluate()
        {
            return this;
        }

        public int getWholeNumber()
        {
            return (int)Math.Floor(value);
        }

        public double getValue()
        {
            return value;
        }

        public bool isInteger()
        {
            return value >= -2147483648 && value <= 2147483647 && value % 1 == 0;
        }
    }
}
