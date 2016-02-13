using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PluginSDK;


namespace MultiDesktop
{
    public class Calculator
    {
        private double ans;

        public Calculator()
        {
            ans = 0;
        }

        private const char MINUS = '−';
        private const char NEGATIVE = '-'; //This is a hyphen
        private const char SQRT = '√';
        private const int DECIMALPLACES = 9; //The same number of decimal places shown on an actual scientific calculator

        public void setRadians()
        {
            TrigonometricExpression.Mode = false;
        }

        public void setDegrees()
        {
            TrigonometricExpression.Mode = true;
        }

        public void clear()
        {
            ans = 0;
        }

        public double compute(string input)
        {
            ans = parseExpression(convert(input)).evaluate();
            ans = Math.Round(ans, DECIMALPLACES); //Round the number to a certain number of decimal places if there are too many digits
            return ans;
        }

        /// <summary>
        /// Parse a mathematical expression in postfix notation into an expression tree.
        /// </summary>
        /// <param name="postFix">A mathematical expression to be parsed.</param>
        /// <returns>Returns the top node of the expression tree.</returns>
        private Expression parseExpression(Queue<Expression> postFix)
        {
            if (postFix.Count == 0)
                throw new ArithmeticException("There is nothing to compute!");

            Stack<Expression> operand = new Stack<Expression>();

            while(postFix.Count > 0)
            {
                Expression expression = postFix.Dequeue();
                if (expression is SingleOperandExpression)
                {
                    SingleOperandExpression n = (SingleOperandExpression)expression;
                    if (operand.Count > 0)
                        n.setOperand(operand.Pop());
                    operand.Push(n);
                }
                else if (expression is TwoOperandExpression)
                {
                    TwoOperandExpression n = (TwoOperandExpression)expression;
                    if (operand.Count > 0)
                        n.setRightOperand(operand.Pop());
                    if (operand.Count > 0)
                        n.setLeftOperand(operand.Pop());
                    operand.Push(n);
                }
                else
                {
                    operand.Push(expression);
                }
            }

            return operand.Pop();
        }

        /// <summary>
        /// Convert a mathematical expression in infix notation into postfix notation.
        /// </summary>
        /// <param name="infix">A mathematical expression to be converted.</param>
        /// <returns>Returns the queue of expressions in postfix notation.</returns>
        private Queue<Expression> convert(string infix)
        {
            //Remove all leading and trailing whitespace characters
            infix = infix.Trim();

            if (infix.Length == 0)
                throw new ArithmeticException("Cannot evaluate empty expression!");

            Queue<Expression> postFix = new Queue<Expression>();
            Stack operators = new Stack();
            
            Regex variable = new Regex("[a-zA-Z_][a-zA-Z0-9]*");
            Regex realNumber = new Regex(@"-?[1-9]?[0-9]*\.?[0-9]+");
            Regex trigFunction = new Regex("(ar(c?))?(sin|cos|tan|csc|sec|cot)(h?)", RegexOptions.IgnoreCase);
            Regex logFunction = new Regex("log|ln", RegexOptions.IgnoreCase);

            int pos = 0;
            Match v = variable.Match(infix);
            Match r = realNumber.Match(infix);

            //Handle special case of using parenthesis instead of multiplication
            bool isPreviousOperator = false;
            bool isPreviousRightParenthesis = false;

            //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
            bool isPreviousLiteral = false;

            //Following the shunting-yard algorithm
            while (pos < infix.Length)
            {
                //Check if there is a match for possible variable or function
                if (v.Index == pos && v.Success)
                {
                    Match t = trigFunction.Match(v.Value);
                    Match l = logFunction.Match(v.Value);

                    //Check if it is a trigonmetric or hyperbolic function
                    if (t.Success && t.Index == 0 && t.Value.Length == v.Value.Length)
                    {
                        //Handle special case of implying multiplication when a literal is before a trigonmetric or hyperbolic function
                        if (isPreviousLiteral)
                        {
                            TwoOperandExpression impliedExpression = new BasicOperationExpression(BasicOp.Multiply);

                            while (operators.Count > 0 && operators.Peek() is OperatorExpression && impliedExpression.CompareTo(operators.Peek()) > 0)
                            {
                                postFix.Enqueue((OperatorExpression)operators.Pop());
                            }

                            operators.Push(impliedExpression);
                        }

                        string func = t.Value.ToLower();
                        
                        //Check if it is a hyperbolic function
                        bool hyperbolic = false;
                        if (func[func.Length - 1] == 'h')
                        {
                            hyperbolic = true;
                            func = func.Substring(0, func.Length - 1);
                        }

                        //Check if it is an inverse function
                        bool inverse = false;
                        if (func.Substring(0, 2).ToLower().Equals("ar"))
                        {
                            inverse = true;
                            if (hyperbolic)
                                func = func.Remove(0, 2);
                            else
                                func = func.Remove(0, 3);
                        }

                        SingleOperandExpression expression;

                        switch (func)
                        {
                            case "sin":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.SINH, inverse) : new TrigonometricExpression(TrigFunc.SIN, inverse);
                                break;
                            case "cos":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.COSH, inverse) : new TrigonometricExpression(TrigFunc.COS, inverse);
                                break;
                            case "tan":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.TANH, inverse) : new TrigonometricExpression(TrigFunc.TAN, inverse);
                                break;
                            case "csc":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.CSCH, inverse) : new TrigonometricExpression(TrigFunc.CSC, inverse);
                                break;
                            case "sec":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.SECH, inverse) : new TrigonometricExpression(TrigFunc.SEC, inverse);
                                break;
                            case "cot":
                                expression = hyperbolic ? (SingleOperandExpression) new HyperbolicExpression(HyperFunc.COTH, inverse) : new TrigonometricExpression(TrigFunc.COT, inverse);
                                break;
                            default: //Never occur case
                                expression = null;
                                break;
                        }

                        while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                        {
                            postFix.Enqueue((OperatorExpression)operators.Pop());
                        }

                        operators.Push(expression);
                        pos += t.Value.Length;

                        isPreviousOperator = true;
                        isPreviousLiteral = false;
                    }
                    //Check if it is a logarithm function
                    else if (l.Success && l.Index == 0 && l.Value.Length == v.Value.Length)
                    {
                        //Handle special case of implying multiplication when a literal is before a logarithm function
                        if (isPreviousLiteral)
                        {
                            TwoOperandExpression impliedExpression = new BasicOperationExpression(BasicOp.Multiply);

                            while (operators.Count > 0 && operators.Peek() is OperatorExpression && impliedExpression.CompareTo(operators.Peek()) > 0)
                            {
                                postFix.Enqueue((OperatorExpression)operators.Pop());
                            }

                            operators.Push(impliedExpression);
                        }

                        string func = l.Value.ToLower();
                        
                        SingleOperandExpression expression;

                        if (func.ToLower().Equals("ln"))
                        {
                            expression = new LogarithmExpression(Math.E);
                        }
                        else
                        {
                            expression = new LogarithmExpression();
                        }

                        while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                        {
                            postFix.Enqueue((OperatorExpression)operators.Pop());
                        }

                        operators.Push(expression);
                        pos += l.Value.Length;

                        isPreviousOperator = true;
                        isPreviousLiteral = false;
                    }
                    //Check if it is ans
                    else if (v.Value.Equals("ans"))
                    {
                        //Handle special case of using parenthesis instead of multiplication
                        if (isPreviousRightParenthesis)
                        {
                            TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                            while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                            {
                                postFix.Enqueue((OperatorExpression)operators.Pop());
                            }

                            operators.Push(expression);
                        }

                        //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
                        if (isPreviousLiteral)
                        {
                            throw new ArithmeticException("There is missing operator(s) or it is out of place!");
                        }

                        postFix.Enqueue(new RealNumber(ans));
                        pos += 3;

                        isPreviousOperator = false;
                        isPreviousLiteral = true;
                    }
                    //Check if it is e
                    else if (v.Value.Equals("e"))
                    {
                        //Handle special case of using parenthesis instead of multiplication
                        if (isPreviousRightParenthesis)
                        {
                            TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                            while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                            {
                                postFix.Enqueue((OperatorExpression)operators.Pop());
                            }

                            operators.Push(expression);
                        }

                        //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
                        if (isPreviousLiteral)
                        {
                            throw new ArithmeticException("There is missing operator(s) or it is out of place!");
                        }

                        postFix.Enqueue(new RealNumber(Math.E));
                        pos++;

                        isPreviousOperator = false;
                        isPreviousLiteral = true;
                    }
                    //Then it must be a variable
                    else
                    {
                        //Handle special case of using parenthesis instead of multiplication
                        if (isPreviousRightParenthesis)
                        {
                            TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                            while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                            {
                                postFix.Enqueue((OperatorExpression)operators.Pop());
                            }

                            operators.Push(expression);
                        }

                        //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
                        if (isPreviousLiteral)
                        {
                            throw new ArithmeticException("There is missing operator(s) or it is out of place!");
                        }

                        postFix.Enqueue(new Variable(v.Value));
                        pos += v.Value.Length;

                        isPreviousOperator = false;
                        isPreviousLiteral = true;
                    }
                    isPreviousRightParenthesis = false;
                }
                //Check if it is a real number
                else if (r.Index == pos && r.Success)
                {
                    //Handle special case of using parenthesis instead of multiplication
                    if (isPreviousRightParenthesis)
                    {
                        TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                        while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                        {
                            postFix.Enqueue((OperatorExpression)operators.Pop());
                        }

                        operators.Push(expression);
                    }

                    //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
                    if (isPreviousLiteral)
                    {
                        throw new ArithmeticException("There is missing operator(s) or it is out of place!");
                    }

                    postFix.Enqueue(new RealNumber(Double.Parse(r.Value)));
                    pos += r.Value.Length;

                    isPreviousOperator = false;
                    isPreviousRightParenthesis = false;
                    isPreviousLiteral = true;
                }
                //Check if it is PI
                else if (infix[pos] == 'π')
                {
                    //Handle special case of using parenthesis instead of multiplication
                    if (isPreviousRightParenthesis)
                    {
                        TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                        while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                        {
                            postFix.Enqueue((OperatorExpression)operators.Pop());
                        }

                        operators.Push(expression);
                    }

                    postFix.Enqueue(new RealNumber(Math.PI));
                    pos++;

                    isPreviousOperator = false;
                    isPreviousRightParenthesis = false;
                    isPreviousLiteral = true;
                }
                //Check if it is a left parenthesis
                else if (infix[pos] == '(')
                {
                    //Handle special case of using parenthesis instead of multiplication
                    if (pos != 0 && !isPreviousOperator || isPreviousRightParenthesis)
                    {
                        TwoOperandExpression expression = new BasicOperationExpression(BasicOp.Multiply);

                        while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                        {
                            postFix.Enqueue((OperatorExpression)operators.Pop());
                        }

                        operators.Push(expression);
                    }

                    operators.Push(infix[pos]);
                    pos++;

                    isPreviousOperator = false;
                    isPreviousRightParenthesis = false;
                    isPreviousLiteral = false;
                }
                //Check if it is a right parenthesis
                else if (infix[pos] == ')')
                {
                    //Pop all operators and add them to the queue until a "(" is found
                    while (operators.Peek().GetType() != typeof(char) || !operators.Peek().Equals('('))
                    {
                        postFix.Enqueue((Expression)operators.Pop());
                    }
                    operators.Pop(); //Dispose '('
                    pos++;

                    isPreviousOperator = false;
                    isPreviousRightParenthesis = true;
                    isPreviousLiteral = false;
                }
                //Check if it is a whitespace
                else if (infix[pos] == ' ')
                {
                    pos++; //Ignore
                }
                //Then it must be a single operator
                else
                {
                    OperatorExpression expression;
                    switch(infix[pos])
                    {
                        case '+':
                            expression = new BasicOperationExpression(BasicOp.Add);
                            break;
                        case MINUS:
                            expression = new BasicOperationExpression(BasicOp.Subtract);
                            break;
                        case '*':
                            expression = new BasicOperationExpression(BasicOp.Multiply);
                            break;
                        case '/':
                            expression = new BasicOperationExpression(BasicOp.Divide);
                            break;
                        case '=':
                            expression = new BasicOperationExpression(BasicOp.Equal);
                            break;
                        case '%':
                            expression = new BasicOperationExpression(BasicOp.Modulo);
                            break;
                        case '^':
                            expression = new PowerExpression();
                            break;
                        case SQRT:
                            expression = new SquareRootExpression();
                            break;
                        case NEGATIVE:
                            //Substitute as "-1 *"
                            postFix.Enqueue(new RealNumber(-1));
                            expression = new BasicOperationExpression(BasicOp.Multiply);
                            break;
                        case '!':
                            expression = new FactorialExpression();
                            break;
                        default:
                            throw new ArithmeticException("Invalid arithmetic symbol or expression!");
                    }

                    while (operators.Count > 0 && operators.Peek() is OperatorExpression && expression.CompareTo(operators.Peek()) > 0)
                    {
                        postFix.Enqueue((OperatorExpression)operators.Pop());
                    }

                    operators.Push(expression);
                    pos++;

                    isPreviousOperator = true;
                    isPreviousRightParenthesis = false;
                    isPreviousLiteral = false;
                }

                //Look for next match if already parsed
                if (v.Index < pos)
                    v = v.NextMatch();
                if (r.Index < pos)
                    r = r.NextMatch();
            }

            //Handle cases of inputting expression in wrong notation (prefix, postfix, etc.)
            if (isPreviousOperator && operators.Peek().GetType() != typeof(FactorialExpression))
            {
                throw new ArithmeticException("There is missing operand(s) or it is out of place!");
            }

            while (operators.Count > 0)
            {
                object remainingOperator = operators.Pop();
                if (remainingOperator is OperatorExpression)
                    postFix.Enqueue((OperatorExpression)remainingOperator);
                else
                    throw new ArithmeticException(String.Format("Expression has extra '{0}'.", remainingOperator.ToString()));
            }

            return postFix;
        }
    }
}
