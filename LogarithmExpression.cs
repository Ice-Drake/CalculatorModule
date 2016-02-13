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

        public override double evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for logarithm function!");

            double value = operand.evaluate();
            if (value < 0)
                throw new ArithmeticException("Cannot logarithm a negative number!");

            if (logBase == 10)
                return Math.Log10(value);
            else
                return Math.Log(value, logBase);
        }
    }
}
