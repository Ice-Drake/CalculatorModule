using System;

namespace MultiDesktop
{
    public class PowerExpression : TwoOperandExpression
    {
        public PowerExpression()
        {
            leftAssociative = false;
            precedence = 3;
        }

        public override double evaluate()
        {
            if (leftOperand == null)
                throw new ArithmeticException("Missing left operand for power function!");
            if (rightOperand == null)
                throw new ArithmeticException("Missing right operand for power function!");
            return Math.Pow(leftOperand.evaluate(), rightOperand.evaluate());
        }
    }
}
