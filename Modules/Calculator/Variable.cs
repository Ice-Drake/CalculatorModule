﻿using System;
using PluginSDK;

namespace MultiDesktop
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
            else if (value is Numeral)
                return (Numeral)value;
            else
                throw new ArgumentException(String.Format("Variable {0} is not a numeral!", Name));
        }
    }
}