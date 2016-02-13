using System;

namespace MultiDesktop
{
    public class FactorialExpression : SingleOperandExpression
    {
        public FactorialExpression()
        {
            leftAssociative = true;
            precedence = 3;
        }

        public override double evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for factorial operation!");
            double value = operand.evaluate();
            if (value < 0)
                throw new ArithmeticException("Cannot evaluate the factorial of a negative number!");
            
            if (value % 1 != 0)
                throw new ArgumentException("Cannot evaluate the factorial of a decimal number!");
            else
                return factorial((int)value);
        }

        private int factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);
        }
    }
}
