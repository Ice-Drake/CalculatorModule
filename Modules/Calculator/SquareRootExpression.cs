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

        public override Numeral evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for square root function!");

            Numeral numeral = operand.evaluate();

            if (numeral.GetType() == typeof(RealNumber))
            {
                double radicand = ((RealNumber)numeral).getValue();

                if (radicand < 0)
                    throw new ArithmeticException("Cannot square root a negative number! Cannot express the value in imaginary number!");
                else
                    return new RealNumber(Math.Sqrt(radicand));
            }
            else
                throw new ArithmeticException(String.Format("Cannot square root {0}!", numeral.TypeName.ToLower()));
        } 
    }
}
