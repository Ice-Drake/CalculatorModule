using System;
using PluginSDK;

namespace CalculatorModule
{
    public class Variable : Expression
    {
        private static SharedData sharedData = new SharedData();

        public string Name { get; private set; }

        public Variable(string name)
        {
            Name = name;
        }

        public Numeral evaluate()
        {
            object value = sharedData.retrieve(Name);
            if (value == null)
                throw new ArithmeticException(String.Format("Variable {0} is undefined!", Name));
            else
                return (Numeral)value;
        }
    }
}
