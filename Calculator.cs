using System;
using System.Collections;
using System.Collections.Generic;


namespace MultiDesktop
{
    public class Calculator
    {
        public string Console { get; private set; }
        public List<string> Variables { get; private set; }
        public List<double> Values { get; private set; }

        public Calculator()
        {
            Variables = new List<string>();
            Values = new List<double>();
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
        private readonly string EQUAL = "=";
        private readonly string precedence2 = "+−";
        private readonly string precedence3 = "*/%";
        private readonly string precedence4 = "^!sincostanloglnasinacosatansinhcoshtanh-√"; //So ugly. Will think of better way later.
        private readonly string[] tokenList = { "sin", "cos", "tan", "log", "ln", "asin", "acos", "atan", "sinh", "cosh", "tanh" };


        public void clear()
        {
            Console = "";
        }
        
        public void resetVariables()
        {
            Variables.Clear();
            Values.Clear();
        }

        public double compute(string input)
        {
            bool storeVariable = false;
            if (input.Contains(EQUAL)) //If it contains an equal sign, then the user is trying to store a variable
            {
                Variables.Add(input.Substring(0, input.IndexOf(EQUAL)));
                input = input.Substring(input.IndexOf(EQUAL) + 1);
                storeVariable = true;
            }
            List<string> postFixed = convert(input);
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

            if (storeVariable)
            {
                Values.Add(Convert.ToDouble(stack.Peek()));
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

        private List<string> convert(string infix)
        {
            List<string> postFix = new List<string>();
            Stack<string> operators = new Stack<string>();
            string aToken = "";

            for (int i = 0; i < infix.Length; i++)
            {
                while (infix[i].Equals(' ')) //Skips over whitespace
                {
                    i++;
                }

                if (Char.IsDigit(infix[i]) || infix[i].Equals('.'))
                {
                    string number = infix[i].ToString();
                    while ((i + 1) < infix.Length && (Char.IsDigit(infix[i + 1]) || infix[i + 1].Equals('.'))) //Concat additional digits to string result  (Allows us to get numbers with more than 1 digit)
                    {
                        i++;
                        number += infix[i];
                    }
                    postFix.Add(number);
                }

                else if(Char.IsLetter(infix[i])) //Variable or trig function
                {
                    aToken += infix[i];
                    bool trig = false;
                    foreach (string token in tokenList)
                    {
                        //Possible bug: tansin0 will NOT work, but tan sin 0 will. tan(sin 0) also works...
                        if (aToken.Equals(token) && !Char.IsLetter(infix[i+1])) //If aToken is a COMPLETE token (E.G. sin and not si) (Also ensures that you can get sinh instead of sin)
                        {
                            operators.Push(aToken);
                            aToken = ""; //Reset aToken
                            trig = true;
                        }
                    }

                    if (!trig)
                    {
                        for (int var = 0; var < Variables.Count; var++)
                        {
                            try
                            {
                                if (aToken.Equals(Variables[var]) && !Char.IsLetter(infix[i + 1])) //May cause out of bounds error
                                {
                                    postFix.Add(Values[var].ToString());
                                    aToken = "";
                                }
                            }
                            catch(IndexOutOfRangeException e)
                            {
                                if (aToken.Equals(Variables[var]))
                                {
                                    postFix.Add(Values[var].ToString());
                                    aToken = "";
                                }
                            }
                        }
                    }
                }

                else if (operators.Count == 0 || infix[i].Equals('(') || precedence4.Contains(infix[i].ToString()))
                {
                    operators.Push(infix[i].ToString());
                }

                else if (infix[i].Equals(')'))
                {
                    while (!operators.Peek().Equals("("))
                    {
                        postFix.Add(operators.Pop());
                    }
                    operators.Pop(); //Disposes of '('
                }

                else //If not ),(, number, or trig function, this character is an operator
                {
                    int precedence = comparePrecedence(infix[i].ToString(), operators.Peek());
                    if (precedence > 0)  //This character has higher precedence
                    {
                        operators.Push(infix[i].ToString());
                    }
                    else if (precedence < 0) //This character has lower precedence
                    {
                        postFix.Add(operators.Pop());
                        i--;
                    }
                    else//This character has the same precedence
                    {
                        postFix.Add(operators.Pop());
                        operators.Push(infix[i].ToString());
                    }
                }
                
            }


            int size = operators.Count;
            for (int i = 0; i < size; i++)
            {
                postFix.Add(operators.Pop());
            }

            return postFix;
        }


        /*
       * Compares operator precedence
       * <param> operator1 the operator to compare with
       * <param> operator2 the operator at the top of the operators stack
       * <return> positive number if operator1 has higher precedence, negative number if lower precedence, 0 if same precedence
       */
        private int comparePrecedence(string operator1, string operator2)
        {
            int thisPrecedence;
            int topPrecedence;
            if (precedence4.Contains(operator1))
            {
                thisPrecedence = 4;
            }
            else if (precedence3.Contains(operator1))
            {
                thisPrecedence = 3;
            }
            else if (precedence2.Contains(operator1))
            {
                thisPrecedence = 2;
            }
            else
            {
                thisPrecedence = 1;
            }

            if (precedence4.Contains(operator2))
            {
                topPrecedence = 4;
            }
            else if (precedence3.Contains(operator2))
            {
                topPrecedence = 3;
            }
            else if (precedence2.Contains(operator2))
            {
                topPrecedence = 2;
            }
            else
            {
                topPrecedence = 1;
            }

            int comparison = thisPrecedence.CompareTo(topPrecedence);
            return comparison;
        }
    }
}
