using System;
using System.Collections.Generic;
using System.Text;

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

        public string convert(string infix)
        {
            StringBuilder postFix = new StringBuilder(); //The string of characters
            var stack = new Stack<char>(); //The stack to push the characters

            stack.Push('(');
            infix = infix + ")";

            for (int i = 0; i < infix.Length; i++)
            {
                char character = infix[i];
                if (character > '0' && character <= '9')
                {
                    postFix.Append(character);
                }

                else
                {
                    if (stack.Count == 0 || stack.Peek().Equals('('))
                    {
                        stack.Push(character);
                    }

                    else if (character.Equals('('))
                    {
                        stack.Push(character);
                    }

                    else if (character.Equals(')'))
                    {
                        while (!stack.Peek().Equals('('))
                        {
                            postFix.Append(stack.Pop());
                        }
                        stack.Pop(); //Disposes of '('
                    }

                    else if (character.Equals('*') || character.Equals('/'))
                    {
                        if (stack.Peek().Equals('+') || stack.Peek().Equals('-'))
                        {
                            stack.Push(character);
                        }

                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            postFix.Append(stack.Pop());
                            stack.Push(character);
                        }

                    }

                    else if (character.Equals('+') || character.Equals('-'))
                    {
                        if (stack.Peek().Equals('+') || stack.Peek().Equals('-'))
                        {
                            postFix.Append(stack.Pop());
                            stack.Push(character);
                        }
                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            postFix.Append(stack.Pop());
                            i--; //Need to test the incoming operator against the new top of stack
                        }
                    }

                }
            }

            int size = stack.Count;
            for (int i = 0; i < size; i++)
            {
                postFix.Append(stack.Pop());
            }

            return postFix.ToString();
        }
    }
}
