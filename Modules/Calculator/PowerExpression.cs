using System;
using PluginSDK;

namespace MultiDesktop
{
    public class PowerExpression : TwoOperandExpression
    {
        public PowerExpression()
        {
            leftAssociative = false;
            precedence = 3;
        }

        public override Numeral evaluate()
        {
            if (leftOperand == null)
                throw new ArithmeticException("Missing left operand for power function!");
            if (rightOperand == null)
                throw new ArithmeticException("Missing right operand for power function!");

            Numeral numeral1 = leftOperand.evaluate();
            Numeral numeral2 = rightOperand.evaluate();

            if (numeral1.GetType() == typeof(RealNumber) && numeral2.GetType() == typeof(RealNumber))
            {
                double operand1 = ((RealNumber)numeral1).getValue();
                double operand2 = ((RealNumber)numeral2).getValue();

                return new RealNumber(Math.Pow(operand1, operand2));
            }
            else
            {
                if (numeral1.GetType() != typeof(RealNumber))
                    throw new ArithmeticException(String.Format("Cannot perform power function on {0}!", numeral1.TypeName.ToLower()));
                else
                    throw new ArithmeticException(String.Format("Cannot perform power function on {0}!", numeral2.TypeName.ToLower()));
            }
        }
    }
}
