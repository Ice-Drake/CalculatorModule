using System;
using System.Collections;
using System.Collections.Generic;
using PluginSDK;


namespace MultiDesktop
{
    public class Calculator
    {
        private SharedData Variables;

        private double ans;
        private bool degrees; //Radians and degrees switch

        public Calculator()
        {
            Variables = new SharedData();
            ans = 0;
            degrees = false;
        }

        private readonly string symbols = "+−/*%^"; //The subtraction symbol is character U+2212 on the Arial Character Map.
        private readonly string SIN = "sin";
        private readonly string COS = "cos";
        private readonly string TAN = "tan";
        private readonly string CSC = "csc";
        private readonly string SEC = "sec";
        private readonly string COT = "cot";
        private readonly string LOG = "log";
        private readonly string LN = "ln";
        private readonly string FACTORIAL = "!";
        private readonly string ASIN = "arcsin";
        private readonly string ACOS = "arccos";
        private readonly string ATAN = "arctan";
        private readonly string ACSC = "arccsc";
        private readonly string ASEC = "arcsec";
        private readonly string ACOT = "arccot";
        private readonly string SINH = "sinh";
        private readonly string COSH = "cosh";
        private readonly string TANH = "tanh";
        private readonly string CSCH = "csch";
        private readonly string SECH = "sech";
        private readonly string COTH = "coth";
        private readonly string SQRT = "√";
        private readonly string EQUAL = "=";
        private readonly string NEGATIVE = "-"; //This is a hyphen

        private readonly string precedence2 = "+−";
        private readonly string precedence3 = "*/%";
        private readonly string precedence4 = "^!sincostancotseccscloglnarcsinarccosarctanarccotarcsecarccscsinhcoshtanhcothsechcsch-√"; //So ugly. Will think of better way later.

        private readonly string[] tokenList = { "sin", "cos", "tan", "cot", "sec", "csc", "log", "ln", "arcsin", "arccos", "arctan", "arccot", "arcsec", "arccsc", "sinh", "cosh", "tanh", "coth", "sech", "csch" };

        public void setRadians()
        {
            degrees = false;
        }

        public void setDegrees()
        {
            degrees = true;
        }


        public double compute(string input)
        {
            bool storeVariable = false;
            string variableName = "";
            if (input.Contains(EQUAL)) //If it contains an equal sign, then the user is trying to store a variable
            {
                if (IsValidVariableName(input))
                {
                    variableName = input.Substring(0, input.IndexOf(EQUAL));
                    variableName = variableName.Replace(" ", "");
                    input = input.Substring(input.IndexOf(EQUAL) + 1);
                    storeVariable = true;
                }
                else
                {
                    throw new ArgumentException("Variable name must start with a letter and cannot contain symbols. Do not use reserved words such as sin/log.");
                }
            }
            List<string> postFixed = convert(input);
            var stack = new Stack<double>();

            for (int i = 0; i < postFixed.Count; i++)
            {
                double retNum;
                if (Double.TryParse(postFixed[i], out retNum)) //If incoming character is a number
                {
                    stack.Push(Convert.ToDouble(postFixed[i]));
                }

                else if (postFixed[i].Equals("π"))
                {
                    stack.Push(Math.PI);
                }

                else if (postFixed[i].Equals("e"))
                {
                    stack.Push(Math.E);
                }

                else if (symbols.Contains(postFixed[i])) //Else If incoming character is an arithmetic symbol
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Input");
                    }
                    double operand = operate(stack.Pop(), stack.Pop(), postFixed[i]);
                    stack.Push(operand);
                }

                else //Else it is a function (Sin, log, etc)
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Why would you put a trig function without a number..? Just why?");
                    }
                    double operand = performFunction(stack.Pop(), postFixed[i]);
                    stack.Push(operand);
                }
            }

            if (!(stack.Count == 1))
            {
                throw new ArgumentException("Invalid Input");
            }

            if (storeVariable)
            {
                Variables.store(variableName, Convert.ToDouble(stack.Peek()));
            }

            ans = Convert.ToDouble(stack.Pop());
            return ans;
        }


        /*
         * Performs a basic arithmetic operation
         * <param> anOperand1 an operand
         * <param> anOperand2 another operand
         * <param> anOperator the operator
         * <return> the answer of the operation
         */
        private double operate(double operand1, double operand2, string anOperator)
        {
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
                if (operand1 == 0)
                {
                    throw new ArgumentException("Cannot divide by 0");
                }
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

        private double performFunction(double operand, string function)
        {
            double convertedOperand = operand;
            if (degrees)
            {
                convertedOperand = operand * Math.PI / 180.0;
            }

            if (function.Equals(SIN))
            {
                return Math.Sin(convertedOperand);
            }

            else if (function.Equals(COS))
            {
                return Math.Cos(convertedOperand);
            }

            else if (function.Equals(TAN))
            {
                return Math.Tan(convertedOperand);
            }

            else if (function.Equals(CSC))
            {
                return 1 / Math.Sin(convertedOperand);
            }

            else if (function.Equals(SEC))
            {
                return 1 / Math.Cos(convertedOperand);
            }

            else if (function.Equals(COT))
            {
                return 1 / Math.Tan(convertedOperand);
            }

            else if (function.Equals(FACTORIAL))
            {
                if (operand == (int)operand && operand >= 0)
                {
                    return factorial((int)operand);
                }
                else
                {
                    throw new ArgumentException("Donald is useless in KH.");
                }
            }

            else if (function.Equals(ASIN))
            {
                return Math.Asin(convertedOperand);
            }

            else if (function.Equals(ACOS))
            {
                return Math.Acos(convertedOperand);
            }

            else if (function.Equals(ATAN))
            {
                return Math.Atan(convertedOperand);
            }

            else if (function.Equals(ACSC))
            {
                return Math.Atan(Math.Sign(convertedOperand) / Math.Sqrt(convertedOperand * convertedOperand - 1));
            }

            else if (function.Equals(ASEC))
            {
                return 2 * Math.Atan(1) - Math.Atan(Math.Sign(convertedOperand) / Math.Sqrt(convertedOperand * convertedOperand - 1));
            }

            else if (function.Equals(ACOT))
            {
                return 2 * Math.Atan(1) - Math.Atan(convertedOperand);
            }

            else if (function.Equals(SINH))
            {
                return Math.Sinh(convertedOperand);
            }

            else if (function.Equals(COSH))
            {
                return Math.Cosh(convertedOperand);
            }

            else if (function.Equals(TANH))
            {
                return Math.Tanh(convertedOperand);
            }

            else if (function.Equals(CSCH))
            {
                return 2 / (Math.Pow(Math.E, convertedOperand) - Math.Pow(Math.E, -convertedOperand));
            }

            else if (function.Equals(SECH))
            {
                return 2 / (Math.Pow(Math.E, convertedOperand) + Math.Pow(-Math.E, convertedOperand));
            }

            else if (function.Equals(COTH))
            {
                return (Math.Pow(Math.E, convertedOperand) + Math.Pow(Math.E, -convertedOperand)) / (Math.Pow(Math.E, convertedOperand) - Math.Pow(Math.E, -convertedOperand));
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

            else if (function.Equals(SQRT))
            {
                return Math.Sqrt(operand);
            }

            else
            {
                throw new ArgumentException("Invalid input"); //The only way to end up here is if the user messed up the # of parenthesis
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

            infix = infix.Replace(" ", "");

            for (int i = 0; i < (infix.Length - 1); i++)
            {
                if (Char.IsDigit(infix[i]) && Char.IsLetter(infix[i+1]))
                {
                    string ohNo = infix[i].ToString() + infix[i+1].ToString();
                    string ohYes = infix[i].ToString() + "*" + infix[i+1].ToString();
                    infix = infix.Replace(ohNo, ohYes);
                }
            }

            for (int i = 0; i < infix.Length; i++)
            {
                if (Char.IsDigit(infix[i]) || infix[i].Equals('.'))
                {
                    string number = infix[i].ToString();
                    while ((i + 1) < infix.Length && (Char.IsDigit(infix[i + 1]) || infix[i + 1].Equals('.')))
                    {
                        i++;
                        number += infix[i];
                    }
                    postFix.Add(number);
                }

                else if (Char.IsLetter(infix[i]))
                {
                    //Possible bug: tansin0 will NOT work, but tan sin 0 will. tan(sin 0) also works...
                    string aToken = infix[i].ToString();
                    while ((i + 1) < infix.Length && (Char.IsLetter(infix[i + 1]) || Char.IsDigit(infix[i + 1])))
                    {
                        i++;
                        aToken += infix[i];
                    }
                    if (aToken.Equals("ans"))
                    {
                        postFix.Add(ans.ToString());
                    }
                    else if (aToken.Equals("e") || aToken.Equals("π"))
                    {
                        postFix.Add(aToken);
                    }
                    else if (IsFunction(aToken))
                    {
                        operators.Push(aToken);
                    }
                    else
                    {
                        if (Variables.retrieve(aToken) != null)
                        {
                            postFix.Add(Variables.retrieve(aToken).ToString());
                        }
                        else
                        {
                            throw new ArgumentException("Not a variable or function");
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



        private bool IsFunction(string input)
        {
            bool IsTrig = false;
            foreach (string token in tokenList)
            {
                if (input.ToLower().Equals(token))
                {
                    IsTrig = true;
                }
            }
            return IsTrig;
        }

        private double SinPiEqualZero()
        {
            string character = SIN;
            double pi = 3.14159265359;
            double zero = 0.0;

            if (character.Equals(Math.Sin(pi)))
            {
                return zero;
            }

            return Double.Parse(character);
        }

        private double TanPiEqualZero()
        {
            string character = TAN;
            double pi = 3.14159265359;
            double zero = 0.0;

            if (character.Equals(Math.Tan(pi)))
            {
                return zero;
            }

            return Double.Parse(character);
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



        private bool IsValidVariableName(string input)
        {
            bool isValid = true;
            string variableName = input.Substring(0, input.IndexOf(EQUAL));
            string[] separator = variableName.Split(' ');
            int n = 0;

            for (int i = 0; i < separator.Length; i++)
            {
                if (separator[i].Equals(""))
                {
                    n++;
                }
            }

            if ((separator.Length - n) > 1)
            {
                isValid = false;
            }

            variableName = variableName.Replace(" ", "");

            if (variableName.Contains("(") || variableName.Contains(NEGATIVE) || variableName.Contains(")"))
            {
                isValid = false;
            }
            for (int i = 0; i < variableName.Length; i++)
            {
                if (symbols.Contains(variableName[i].ToString()))
                {
                    isValid = false;
                }
            }
            if (IsFunction(variableName) || variableName.Equals("e") || variableName.Equals("π") || Char.IsDigit(variableName[0]))
            {
                isValid = false;
            }
            return isValid;
        }

    }
}
