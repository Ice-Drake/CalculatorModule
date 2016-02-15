using System;

namespace MultiDesktop
{
    public class LogarithmExpression : SingleOperandExpression
    {
        private double logBase;

        public LogarithmExpression(double logBase = 10)
        {
            leftAssociative = false;
            precedence = 3;
            this.logBase = logBase;
        }

        public override Numeral evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for logarithm function!");

            Numeral numeral = operand.evaluate();

            if (numeral.GetType() == typeof(RealNumber))
            {
                double value = ((RealNumber)numeral).getValue();

                if (value < 0)
                    throw new ArithmeticException("Cannot logarithm a negative number!");

                if (logBase == 10)
                    return new RealNumber(Math.Log10(value));
                else
                    return new RealNumber(Math.Log(value, logBase));
            }
            else
                throw new ArithmeticException(String.Format("Cannot logarithm {0}!", numeral.TypeName.ToLower()));
        }
    }
}
