using System;
using System.Collections;
using System.Collections.Generic;


namespace MultiDesktop
{
    public class Calculator
    {
        public string Console { get; private set; }

        public Calculator()
        {

        }

        private readonly string symbols = "+−/*%^"; //The subtraction symbol is character U+2212 on the Arial Character Map.
        private readonly string SIN = "sin";
        private readonly string COS = "cos";
        private readonly string TAN = "tan";
        private readonly string LOG = "log";
        private readonly string FACTORIAL = "!";
        private readonly string ASIN = "asin";
        private readonly string ACOS = "acos";
        private readonly string ATAN = "atan";
        private readonly string SINH = "sinh";
        private readonly string COSH = "cosh";
        private readonly string TANH = "tanh";
        private readonly string LN = "ln";
        private readonly string NEGATIVE = "-"; //This is a hyphen
        private readonly string SQRT = "√";

        public void clear()
        {
            Console = "";
        }


        public double compute(string input)
        {
            Postfixer postFixer = new Postfixer();
            List<string> postFixed = postFixer.convert(input);
            var stack = new Stack<string>();


            for (int i = 0; i < postFixed.Count; i++)
            {
                double retNum;
                if (Double.TryParse(postFixed[i], out retNum)) //If incoming character is a number
                {
                    stack.Push(postFixed[i]);
                }

                else if (symbols.Contains(postFixed[i])) //Else If incoming character is an arithmetic symbol
                {
                    string operand = operate(stack.Pop(), stack.Pop(), postFixed[i]).ToString();
                    stack.Push(operand);
                }

                else //Else it is a function (Sin, log, etc)
                {
                    string operand = performFunction(stack.Pop(), postFixed[i]).ToString();
                    stack.Push(operand);
                }
            }

            return Convert.ToDouble(stack.Pop());
        }


        /*
         * Performs a basic arithmetic operation
         * <param> anOperand1 an operand
         * <param> anOperand2 another operand
         * <param> anOperator the operator
         * <return> the answer of the operation
         */
        private double operate(string anOperand1, string anOperand2, string anOperator)
        {
            double operand1 = Convert.ToDouble(anOperand1);
            double operand2 = Convert.ToDouble(anOperand2);
            double output = 0;

            if (anOperator.Equals("+"))
            {
                output = operand2 + operand1;
            }
            else if (anOperator.Equals("−"))
            {
                output = operand2 - operand1;
            }
            else if (anOperator.Equals("*"))
            {
                output = operand2 * operand1;
            }
            else if (anOperator.Equals("/"))
            {
                output = operand2 / operand1;
            }
            else if (anOperator.Equals("%"))
            {
                output = operand2 % operand1;
            }
            else if (anOperator.Equals("^"))
            {
                output = Math.Pow(operand2, operand1);
            }
            return output;
        }

        private double performFunction(string anOperand, string function)
        {
            double operand = Convert.ToDouble(anOperand);
            if (function.Equals(SIN))
            {
                return Math.Sin(operand);
            }

            else if (function.Equals(COS))
            {
                return Math.Cos(operand);
            }

            else if (function.Equals(TAN))
            {
                return Math.Tan(operand);
            }

            else if (function.Equals(FACTORIAL))
            {
                return factorial((int)operand);
            }

            else if (function.Equals(ASIN))
            {
                return Math.Asin(operand);
            }

            else if (function.Equals(ACOS))
            {
                return Math.Acos(operand);
            }

            else if (function.Equals(ATAN))
            {
                return Math.Atan(operand);
            }

            else if (function.Equals(SINH))
            {
                return Math.Sinh(operand);
            }

            else if (function.Equals(COSH))
            {
                return Math.Cosh(operand);
            }

            else if (function.Equals(TANH))
            {
                return Math.Tanh(operand);
            }

            else if (function.Equals(LOG))
            {
                return Math.Log10(operand);
            }

            else if (function.Equals(LN))
            {
                return Math.Log(operand, Math.E);
            }

            else if (function.Equals(NEGATIVE))
            {
                return 0.0 - operand;
            }

            else
            {
                return Math.Sqrt(operand);
            }
        }


        private int factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
