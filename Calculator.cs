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
            var operands = new Stack<string>();
            var operators = new Stack<string>();



            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= '0' && input[i] <= '9') ) //If this character is a number
                {
                    string result = "";
                    while (input[i] >= '0' && input[i] <= '9') //Concat additional digits to string result  (Allows us to get numbers with more than 1 digit)
                    {
                        result += input[i];
                        if (i < input.Length - 1)
                        {
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    operands.Push(result);

                    if (!(i == input.Length - 1))
                    {
                        i--; //Don't wanna skip the next operator; the for loop will increment the i back
                    }
                }

                else if (input[i].Equals(')')) //If this character is a closing parenthesis
                {
                    while (!operators.Peek().Equals("(")) //While the top of the operators stack is not an opening parenthesis
                    {
                        double anOperand = operate(operands.Pop(), operands.Pop(), operators.Pop());
                        operands.Push(anOperand.ToString());
                    }
                    operators.Pop(); //Disposes of '('
                }

                else //If not a number or trig function, then it's an operator
                {
                    if (operators.Count == 0 || input[i].Equals('(')) //If operator stack is empty or input is left parenthesis, push the operator onto the stack
                    {
                        operators.Push(input[i].ToString());
                    }
                    else if (input[i].Equals('*') || input[i].Equals('/'))
                    {
                        if (operators.Peek().Equals("+") || operators.Peek().Equals("-") || operators.Peek().Equals('(')) //Input character has higher precedence
                        {
                            operators.Push(input[i].ToString());
                        }
                        else if (operators.Peek().Equals("*") || operators.Peek().Equals("/"))//Input character has same precedence
                        {
                            double result = operate(operands.Pop(), operands.Pop(), operators.Pop());
                            operands.Push(result.ToString());
                            operators.Push(input[i].ToString());
                        }
                    }

                    else if (input[i].Equals('+') || input[i].Equals('-'))
                    {
                        if (operators.Peek().Equals("*") || operators.Peek().Equals("/")) //Input character has lower precedence
                        {
                            double result = operate(operands.Pop(), operands.Pop(), operators.Pop());
                            operands.Push(result.ToString());
                            i--;
                        }
                        else if (operators.Peek().Equals("+") || operators.Peek().Equals("-")) //Input character has same precedence
                        {
                            double result = operate(operands.Pop(), operands.Pop(), operators.Pop());
                            operands.Push(result.ToString());
                            operators.Push(input[i].ToString());
                        }
                        else //Input character has higher precedence
                        {
                            operators.Push(input[i].ToString());
                        }

                    }
                }
            }

            double answer = 0;
            while (operands.Count >= 2) //While operand stack still has 2 or more numbers, perform operations
            {
                answer = operate(operands.Pop(), operands.Pop(), operators.Pop());
                if (operators.Count != 0) //If there are still more operators, push the result into the operand stack
                {
                    operands.Push(answer.ToString());
                }
            }
            return answer; 

        }


        private double operate(string anOperand1, string anOperand2, string anOperator)
        {

            double operand1 = Convert.ToDouble(anOperand1);
            double operand2 = Convert.ToDouble(anOperand2);
            double answer = 0;

            if (anOperator.Equals("+"))
            {
                answer = operand2 + operand1;
            }
            else if (anOperator.Equals("-"))
            {
                answer = operand2 - operand1;
            }
            else if (anOperator.Equals("*"))
            {
                answer = operand2 * operand1;
            }
            else if (anOperator.Equals("/"))
            {
                answer = operand2 / operand1;
            }
            return answer;
        }
    }
}
