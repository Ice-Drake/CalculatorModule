using System;
using System.Collections.Generic;

namespace MultiDesktop
{
    public class Postfixer
    {
        public Stack<string> Operator { get; private set; }
        public Stack<string> Operand { get; private set; }
        
        public Postfixer()
        {
            Operator = new Stack<string>();
            Operand = new Stack<string>();
        }

        public void convert(string infix)
        {

        }
    }
}
