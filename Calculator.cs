using System;
using System.Collections.Generic;

namespace MultiDesktop
{
    public class Calculator
    {
        public string Console { get; private set; }

        public Calculator()
        {

        }

        public void clear()
        {
            Console = "";
        }

        public double compute(string input)
        {
            Postfixer postFixer = new Postfixer();
            postFixer.convert(input);



            return 0;
        }
    }
}
