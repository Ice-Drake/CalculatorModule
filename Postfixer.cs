using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDesktop
{
    public class Postfixer
    {
        private readonly string precedence2 = "+−";
        private readonly string precedence3 = "*/%";
        private readonly string precedence4 = "^!sincostanloglnasinacosatansinhcoshtanh-√"; //So ugly. Will think of better way later.
        private readonly string[] tokenList = { "sin", "cos", "tan", "log", "ln", "asin", "acos", "atan", "sinh", "cosh", "tanh"  };

        public List<string> convert(string infix)
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

                //May cause issues with stored variables. (This only works with trig functions)
                else if(Char.IsLetter(infix[i]))
                {
                    aToken += infix[i];
                    foreach (string token in tokenList)
                    {
                        if (aToken.Equals(token) && !Char.IsLetter(infix[i+1])) //If aToken is a COMPLETE token (E.G. sin and not si)
                        {
                            operators.Push(aToken);
                            aToken = ""; //Reset aToken
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
