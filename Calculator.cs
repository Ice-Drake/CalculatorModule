using System;
using System.Collections;
using System.Collections.Generic;


namespace MultiDesktop
{
    public class Calculator
    {
        public string Console { get; private set; }

        Stack stack = new Stack(); //The normal stack 
        Stack reverse = new Stack(); //The other stack

        public Calculator()
        {

        }

        private readonly string symbols = "+-/*%^";
        private readonly string SIN = "sin";
        private readonly string COS = "cos";
        private readonly string TAN = "tan";
        private readonly string LOG = "log";
        private readonly string FACTORIAL = "!";


        private double calculate;
        private double number1;
        private double number2;
        private string total;
        private string final;
        private char operation;
        private bool input = true;

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            check();
            reverseStack();

            while (stack.Count != 0)
            {
                reverse.Push(stack.Pop());
            }

        }

        private void Reset()
        {
            stack.Clear();
            reverse.Clear();
            calculate = 0;
            number1 = 0;
            number2 = 0;
            total = " ";
            final = " ";
            input = true;
        }

        private void reverseStack()
        {
            while (stack.Count != 0)
            {
                reverse.Push(stack.Pop());
            }
        }

        private void check()
        {
            while (reverse.Count != 0)
            {
                stack.Push(reverse.Pop());
            }
        }

        private void checkOther(char e)
        {
            switch (e)
            {
                case '+':
                    while (reverse.Count != 0)
                    {
                        stack.Push(reverse.Pop());
                    }

                    reverse.Push(e);

                    break;

                case '-':
                    while (reverse.Count != 0)
                    {
                        stack.Push(reverse.Pop());
                    }

                    reverse.Push(e);

                    break;

                case '*':
                    while (reverse.Count != 0)
                    {
                        stack.Push(reverse.Pop());
                    }

                    reverse.Push(e);

                    break;

                case '/':
                    while (reverse.Count != 0)
                    {
                        stack.Push(reverse.Pop());
                    }

                    reverse.Push(e);

                    break;

                case '(':
                    reverse.Push(e);
                    {
                        break;
                    }
            }
        }

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
            else if (anOperator.Equals("-"))
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
                output = Math.Pow(operand2,operand1);
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

            else if(function.Equals(COS))
            {
                return Math.Cos(operand);
            }

            else if (function.Equals(TAN))
            {
                return Math.Tan(operand);
            }

            else if (function.Equals("!"))
            {
                return factorial((int) operand);
            }

            else
            {
                return Math.Log10(operand);
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
