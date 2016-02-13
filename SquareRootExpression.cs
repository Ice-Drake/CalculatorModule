using System;

namespace MultiDesktop
{
    public class SquareRootExpression : SingleOperandExpression
    {
        public SquareRootExpression()
        {
            leftAssociative = false;
            precedence = 3;
        }

        public override double evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for square root function!");
            double radicand = operand.evaluate();
            if (radicand < 0)
                throw new ArithmeticException("Cannot square root a negative number! Cannot express the value in imaginary number!");
            else
                return Math.Sqrt(radicand);
        } 
    }
}
