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

        public override Numeral evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for factorial operation!");
            
            Numeral numeral = operand.evaluate();

            if (numeral.GetType() == typeof(RealNumber))
            {
                double value = ((RealNumber)numeral).getValue();

                if (value < 0)
                    throw new ArithmeticException("Cannot evaluate the factorial of a negative number!");
                else if (value % 1 != 0)
                    throw new ArgumentException("Cannot evaluate the factorial of a decimal number!");
                else
                    return new RealNumber(factorial((uint)value));
            }
            else
                throw new ArithmeticException(String.Format("Cannot evaluate the factorial of {0}!", numeral.TypeName.ToLower()));
        }

        private uint factorial(uint n)
        {
            if (n == 0)
                return 1;
            else
                return n * factorial(n - 1);
        }
    }
}
