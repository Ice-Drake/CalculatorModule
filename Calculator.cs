﻿using System;
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

        private const string operators = "+−/*%^"; //The subtraction symbol is character U+2212 on the Arial Character Map.
        private const string SIN = "sin";
        private const string COS = "cos";
        private const string TAN = "tan";
        private const string CSC = "csc";
        private const string SEC = "sec";
        private const string COT = "cot";
        private const string LOG = "log";
        private const string LN = "ln";
        private const string FACTORIAL = "!";
        private const string ASIN = "arcsin";
        private const string ACOS = "arccos";
        private const string ATAN = "arctan";
        private const string ACSC = "arccsc";
        private const string ASEC = "arcsec";
        private const string ACOT = "arccot";
        private const string SINH = "sinh";
        private const string COSH = "cosh";
        private const string TANH = "tanh";
        private const string CSCH = "csch";
        private const string SECH = "sech";
        private const string COTH = "coth";
        private const string ASINH = "arcsinh";
        private const string ACOSH = "arccosh";
        private const string ATANH = "arctanh";
        private const string ACSCH = "arccsch";
        private const string ASECH = "arcsech";
        private const string ACOTH = "arccoth";
        private const string SQRT = "√";
        private const string EQUAL = "=";
        private const string NEGATIVE = "-"; //This is a hyphen

        private const int DECIMALPLACES = 9; //The same number of decimal places shown on an actual scientific calculator

        private readonly List<string> lowPrecedence = new List<string>(new string[]{ "+", "−" });
        private readonly List<string> midPrecedence = new List<string>(new string[]{ "*", "/", "%" });
        private readonly List<string> highPrecedence = new List<string>(new string[]{ "^", FACTORIAL, SIN, COS, TAN, COT, SEC, CSC, LOG, LN, ASIN, ACOS, ATAN, ACOT, ASEC, ACSC, SINH, COSH, TANH, COTH, SECH, CSCH, ASINH, ACOSH, ATANH, ACOTH, ASECH, ACSCH, NEGATIVE, SQRT });
        private readonly List<string> tokenList = new List<string>(new string[]{ SIN, COS, TAN, COT, SEC, CSC, LOG, LN, ASIN, ACOS, ATAN, ACOT, ASEC, ACSC, SINH, COSH, TANH, COTH, SECH, CSCH, ASINH, ACOSH, ATANH, ACOTH, ASECH, ACSCH, NEGATIVE });

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
            string variableName = "";
            if (input.Contains(EQUAL)) //If it contains an equal sign, then the user is trying to store a variable
            {
                variableName = input.Substring(0, input.IndexOf(EQUAL)).Trim();
                if (IsValidVariableName(variableName))
                    input = input.Substring(input.IndexOf(EQUAL) + 1);
                else
                    throw new ArgumentException("Variable name must start with a letter and cannot contain symbols. Do not use reserved words such as sin/log.");
            }

            List<string> inputs = tokenize(input); //Break input into tokens
            fixSyntax(inputs); //Add "*" where necessary
            if (!IsCorrectSyntax(inputs))
                throw new ArgumentException("Invalid input");
            List<string> postFixed = convert(inputs); //Convert the infix expression to postfix
            var operandStack = new Stack<double>();

            for (int i = 0; i < postFixed.Count; i++)
            {
                //Push all operands onto the stack
                if (Char.IsDigit(postFixed[i][0]) || postFixed[i][0].Equals("."))
                {
                    operandStack.Push(Convert.ToDouble(postFixed[i]));
                }
                else if (postFixed[i].Equals("π"))
                {
                    operandStack.Push(Math.PI);
                }
                else if (postFixed[i].Equals("e"))
                {
                    operandStack.Push(Math.E);
                }
                else if (postFixed[i].Equals("ans"))
                {
                    operandStack.Push(ans);
                }
                else if (operators.Contains(postFixed[i])) //If incoming token is an arithmetic symbol
                {
                    if (operandStack.Count < 2)
                        throw new ArgumentException("Invalid Input");
                    double operand = operate(operandStack.Pop(), operandStack.Pop(), postFixed[i]); //Pop top 2 operands and perform the operation
                    operandStack.Push(operand);
                }
                else //Else it is a function (Sin, log, etc)
                {
                    if (operandStack.Count < 1)
                        throw new ArgumentException("Invalid Input");
                    double operand = performFunction(operandStack.Pop(), postFixed[i]); //Perform the function on the operand at the top of the stack
                    operandStack.Push(operand);
                }
            }

            if (operandStack.Count != 1)
                throw new ArgumentException("Invalid Input");
            ans = Convert.ToDouble(operandStack.Pop());
            ans = Math.Round(ans, DECIMALPLACES); //Round the number to a certain number of decimal places if there are too many digits
            if (!variableName.Equals(""))
                Variables.store(variableName, ans);
            return ans;
        }

        /*
         * Checks if the infix syntax is (roughly) correct.
         * <param> tokens the tokens of the infix expression
         * <return> true if the syntax is (roughly) correct, false otherwise
         */
        public bool IsCorrectSyntax(List<string> tokens)
        {
            //Expression cannot start or end with an operator
            if (operators.Contains(tokens[0]) || operators.Contains(tokens[tokens.Count - 1]))
                return false;

            for (int i = 0; i < tokens.Count - 1; i++)
            {
                //Cannot contain empty set of parenthesis
                if (tokens[i].Equals("(") && tokens[i + 1].Equals(")"))
                    return false;
                //Cannot contain two decimal points in a row
                else if (tokens[i].Contains(".."))
                    return false;
            }

            //For loop above doesn't check last element
            if (tokens[tokens.Count - 1].Contains(".."))
                return false;

            //Checks for balanced parenthesis
            int parenthesisCounter = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Equals("("))
                    parenthesisCounter++;
                else if (tokens[i].Equals(")"))
                    parenthesisCounter--;

                if (parenthesisCounter < 0)
                    return false;
            }
            return parenthesisCounter == 0;
        }

        /*
         * Checks if the input string is a valid variable name. Variable names must start with a letter, contain no white spaces, contain no mathematical symbols, and cannot equal reserved terms such as "ans" or "sin"
         * <param> input the input string
         * <return> true if the string meets the conditions, false otherwise
         */
        private bool IsValidVariableName(string input)
        {
            if (input.Equals("") || input.Contains(" ") || input.Contains("(") || input.Contains(NEGATIVE) || input.Contains(")") || input.Contains("π") || tokenList.Contains(input) || input.Equals("e") || Char.IsDigit(input[0]) || input.Equals("ans"))
                return false;

            for (int i = 0; i < operators.Length; i++)
            {
                if (input.Contains(operators[i].ToString()))
                    return false;
            }
            return true;
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
                    throw new ArgumentException("Cannot divide by 0");
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

        /*
         * Performs a mathematical function on the operand
         * <param> operand an operand
         * <param> function the mathematical function
         * <return> the answer of the operation
         */
        private double performFunction(double operand, string function)
        {
            double convertedOperand = operand;
            if (degrees && !function[0].Equals('a')) //Convert to radians for calculator to calculate if this function is not an inverse function
                convertedOperand = operand * Math.PI / 180.0;
            double result = 0;
            switch (function)
            {
                case SIN:
                    result = Math.Sin(convertedOperand);
                    break;
                case COS:
                    result = Math.Cos(convertedOperand);
                    break;
                case TAN:
                    result = Math.Tan(convertedOperand);
                    break;
                case CSC:
                    result = 1 / Math.Sin(convertedOperand);
                    break;
                case SEC:
                    result = 1 / Math.Cos(convertedOperand);
                    break;
                case COT:
                    result = 1 / Math.Tan(convertedOperand);
                    break;
                case ASIN:
                    result = Math.Asin(convertedOperand);
                    break;
                case ACOS:
                    result = Math.Acos(convertedOperand);
                    break;
                case ATAN:
                    result = Math.Atan(convertedOperand);
                    break;
                case ACSC:
                    result = Math.Asin(1 / convertedOperand);
                    break;
                case ASEC:
                    result = Math.Acos(1 / convertedOperand);
                    break;
                case ACOT:
                    result = Math.PI / 2 - Math.Atan(convertedOperand);
                    break;
                case SINH:
                    result = Math.Sinh(convertedOperand);
                    break;
                case COSH:
                    result = Math.Cosh(convertedOperand);
                    break;
                case TANH:
                    result = Math.Tanh(convertedOperand);
                    break;
                case CSCH:
                    result = 1 / Math.Sinh(convertedOperand);
                    break;
                case SECH:
                    result = 1 / Math.Cosh(convertedOperand);
                    break;
                case COTH:
                    result = 1 / Math.Tanh(convertedOperand);
                    break;
                case ASINH:
                    result = Math.Log(convertedOperand + Math.Sqrt(Math.Pow(convertedOperand, 2) + 1), Math.E);
                    break;
                case ACOSH:
                    result = Math.Log(convertedOperand + Math.Sqrt(Math.Pow(convertedOperand, 2) - 1), Math.E);
                    break;
                case ATANH:
                    result = Math.Log((1 + convertedOperand) / (1 - convertedOperand) , Math.E) / 2.0;
                    break;
                case ACSCH:
                    if (convertedOperand > 0)
                        result = Math.Log((1 + Math.Sqrt(Math.Pow(convertedOperand, 2) + 1)) / convertedOperand, Math.E);
                    else
                        result = Math.Log((1 - Math.Sqrt(Math.Pow(convertedOperand, 2) + 1)) / convertedOperand, Math.E);
                    break;
                case ASECH:
                    result = Math.Log((1 / convertedOperand) + Math.Sqrt(Math.Pow(1 / convertedOperand, 2) - 1), Math.E);
                    break;
                case ACOTH:
                    result = Math.Log((convertedOperand + 1) / (convertedOperand - 1), Math.E) / 2.0;
                    break;
                //The functions below are NOT trig functions, so they use operand instead of convertedOperand
                case LOG:
                    result = Math.Log10(operand);
                    break;
                case LN:
                    result = Math.Log(operand, Math.E);
                    break;
                case FACTORIAL:
                    //Checks if the operand is both positive and is an integer
                    if (operand == (int)operand && operand >= 0)
                        result = factorial((int)operand);
                    else
                        throw new ArgumentException("Factorial Error: Not an integer or not positive");
                    break;
                case SQRT:
                    result = Math.Sqrt(operand);
                    break;
                case NEGATIVE:
                    result = 0.0 - operand;
                    break;
            }
            if (degrees && function[0].Equals('a')) //If this is an inverse function, convert the result to degrees before returning
                result = result * 180.0 / Math.PI;
            return result;
        }

        private int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);
        }

        /*
       * Compares operator priority order
       * <param> operator1 the operator to compare with
       * <param> operator2 the operator at the top of the operators stack
       * <return> positive number if operator1 has higher precedence, negative number if lower precedence, 0 if same precedence
       */
        private int comparePrecedence(string operator1, string operator2)
        {
            int thisPrecedence;
            int topPrecedence;
            if (highPrecedence.Contains(operator1))
                thisPrecedence = 4;
            else if (midPrecedence.Contains(operator1))
                thisPrecedence = 3;
            else if (lowPrecedence.Contains(operator1))
                thisPrecedence = 2;
            else
                thisPrecedence = 1;

            if (highPrecedence.Contains(operator2))
                topPrecedence = 4;
            else if (midPrecedence.Contains(operator2))
                topPrecedence = 3;
            else if (lowPrecedence.Contains(operator2))
                topPrecedence = 2;
            else
                topPrecedence = 1;

            return thisPrecedence.CompareTo(topPrecedence);
        }

        /*
       * Breaks the mathematical expression into tokens
       * <param> input the input string
       * <return> a list of the input broken into tokens
       */
        private List<string> tokenize(string input)
        {
            List<string> tokens = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string token = "";

                //If the character is a digit or decimal point, extract the rest of the number
                if (Char.IsDigit(input[i]) || input[i].Equals('.'))
                {
                    while (i < input.Length && (Char.IsDigit(input[i]) || input[i].Equals('.')))
                    {
                        token += input[i];
                        i++;
                    }
                    i--;
                }
                //If the character is a letter, extract the rest of the math function/variable name
                else if (Char.IsLetter(input[i]))
                {
                    while (i < input.Length && (Char.IsLetterOrDigit(input[i]) || input[i].Equals('.')))
                    {
                        token += input[i];
                        i++;
                    }
                    i--;
                }
                //Else, the token is 1 character long (Operators, parenthesis, etc)
                else
                {
                    token += input[i];
                }

                if (!token.Equals(" "))
                    tokens.Add(token);
            }
            return tokens;
        }

        /*
       * Adds a "*" symbol between operands for implied multiplication. Also adds a 0 in front of numbers such as .5
       * <param> tokens a list of tokens
       */
        private void fixSyntax(List<string> tokens)
        {
            //Attaches a 0 to the front of numbers that need it. E.g. .6 --> 0.6
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].StartsWith("."))
                    tokens[i] = "0" + tokens[i];
            }

            for (int i = 0; i < tokens.Count - 1; i++)
            {
                //Inserts "*" if a letter or '(' is found after a number. E.g: 4sin --> 4 * sin
                if (Char.IsDigit(tokens[i][0]) && (Char.IsLetter(tokens[i + 1][0]) || tokens[i + 1].Equals("(")))
                {
                    tokens.Insert(i + 1, "*");
                    i++;
                }

                //Inserts "*" if a number, negative sign, or math function/variable is found after a ")". E.g: (4+2)a --> (4+2) * a
                else if (tokens[i].Equals(")") && (Char.IsLetterOrDigit(tokens[i + 1][0]) || tokens[i+1].Equals(NEGATIVE)))
                {
                    tokens.Insert(i + 1, "*");
                    i++;
                }
            }
        }

        /*
       * Converts an infix expression into postfix
       * <param> infix the infix string
       * <return> a list of the postfix expression broken into tokens
       */
        private List<string> convert(List<string> infix)
        {
            List<string> postFix = new List<string>();
            Stack<string> operators = new Stack<string>(); //A stack used to perform the shunting yard algorithm

            for (int i = 0; i < infix.Count; i++)
            {
                string input = infix[i];
                if (Char.IsDigit(input[0]) || input[0].Equals(".")) //If input is a number add it to the list
                {
                    postFix.Add(input);
                }
                //If ans, add the previous ans to the list
                else if (input.Equals("ans"))
                {
                    postFix.Add(ans.ToString());
                }
                else if (input.Equals("e") || input.Equals("π")) //If e or pi, add to the list
                {
                    postFix.Add(input);
                }
                //If a function, push to top of operator stack
                else if (tokenList.Contains(input))
                {
                    operators.Push(input);
                }
                //If a valid variable name, add its value to the list
                else if (Variables.retrieve(input) != null)
                {
                    string value = Variables.retrieve(input).ToString();
                    if (value.StartsWith(NEGATIVE)) //If the variable holds a negative value, treat them separately
                    {
                        value = value.Replace(NEGATIVE, "");
                        operators.Push(NEGATIVE);
                    }
                    postFix.Add(value);
                }
                //If it starts with a letter and it isn't a function, variable, etc, throw an exception
                else if (Char.IsLetter(input[0]))
                {
                    throw new ArgumentException("Invalid input");
                }
                //If the first operator, an operator of precedence 4, or a left parenthesis, push to top of operator stack
                else if (operators.Count == 0 || input.Equals("(") || highPrecedence.Contains(input))
                {
                    operators.Push(input);
                }
                //If a right parenthesis...
                else if (input.Equals(")"))
                {
                    //Pop all operators and add them to the list until a "(" is found
                    while (!operators.Peek().Equals("("))
                    {
                        postFix.Add(operators.Pop());
                    }
                    operators.Pop(); //Disposes of '('
                }

                else //Is an operator
                {
                    //Compare the priorities of the operator at the top of the stack and the current operator
                    int precedence = comparePrecedence(input, operators.Peek());
                    if (precedence > 0)  //This token has higher precedence, push to top of operator stack
                    {
                        operators.Push(input);
                    }
                    else if (precedence < 0) //This token has lower precedence, pop the operator to the list
                    {
                        postFix.Add(operators.Pop());
                        i--; //Decrement i, so we don't skip the current element
                    }
                    else//This token has the same precedence, pop the operator to the list, and push this operator onto the stack
                    {
                        postFix.Add(operators.Pop());
                        operators.Push(input);
                    }
                }
            }

            while (operators.Count != 0)
                postFix.Add(operators.Pop()); //Pop all remaining operators

            return postFix;
        }
    }
}
