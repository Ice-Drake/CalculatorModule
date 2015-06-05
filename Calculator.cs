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


        private readonly string precedence2 = "+-";
        private readonly string precedence3 = "*/%";
        private readonly string precedence4 = "^!";
        

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
                if (Char.IsDigit(input[i]) || input[i].Equals('.')) //If this character is a number or decimal point
                {
                    string result = "";
                    while (Char.IsDigit(input[i]) || input[i].Equals('.')) //Concat additional digits to string result  (Allows us to get numbers with more than 1 digit)
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

                else if (operators.Count == 0 || input[i].Equals('(')) //If operator stack is empty or input is left parenthesis, push the operator onto the stack
                {
                    operators.Push(input[i].ToString());
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

                else //If not ),(, number, or trig function, this character is an operator
                {
                    int precedence = comparePrecedence(input[i].ToString(), operators.Peek());
                    if (precedence > 0)  //This character has higher precedence
                    {
                        operators.Push(input[i].ToString());
                    }
                    else if (precedence < 0) //This character has lower precedence
                    {
                        double result = operate(operands.Pop(), operands.Pop(), operators.Pop());
                        operands.Push(result.ToString());
                        i--;
                    }
                    else //This character has the same precedence
                    {
                        if (input[i].Equals('^')) //Right associativity
                        {
                            operators.Push(input[i].ToString());
                        }
                        else //Left associativity
                        {
                            double result = operate(operands.Pop(), operands.Pop(), operators.Pop());
                            operands.Push(result.ToString());
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
            else if (anOperator.Equals("%"))
            {
                answer = operand2 % operand1;
            }
            else if (anOperator.Equals("^"))
            {
                answer = Math.Pow(operand2,operand1);
            }
            return answer;
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
