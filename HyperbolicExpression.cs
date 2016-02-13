using System;

namespace MultiDesktop
{
    public enum HyperFunc
    {
        SINH,
        COSH,
        TANH,
        CSCH,
        SECH,
        COTH,
    }

    public class HyperbolicExpression : SingleOperandExpression
    {
        private HyperFunc func;
        private bool inverse;

        public HyperbolicExpression(HyperFunc func, bool inverse = false)
        {
            this.func = func;
            this.inverse = inverse;
            leftAssociative = false;
            precedence = 3;
        }

        public override double evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for hyperbolic function!");

            double value = operand.evaluate();

            switch (func)
            {
                case HyperFunc.SINH:
                    return inverse ? Math.Log(value + Math.Sqrt(Math.Pow(value, 2) + 1), Math.E) : Math.Sinh(value);
                case HyperFunc.COSH:
                    return inverse ? Math.Log(value + Math.Sqrt(Math.Pow(value, 2) - 1), Math.E) : Math.Cosh(value);
                case HyperFunc.TANH:
                    return inverse ? Math.Log((1 + value) / (1 - value), Math.E) / 2 : Math.Tanh(value);
                case HyperFunc.CSCH:
                    if (inverse)
                    {
                        if (value != 0)
                            return Math.Log((1 / value) + Math.Sqrt(1 + 1 / Math.Pow(value, 2)), Math.E);
                        else
                            throw new ArithmeticException("arcsch is undefined at 0!");
                    }
                    else
                    {
                        if (value != 0)
                            return 1 / Math.Sinh(value);
                        else
                            throw new ArithmeticException("csch is undefined at 0!");
                    }
                case HyperFunc.SECH:
                    if (inverse)
                    {
                        if (value > 0 && value <= 1)
                            return Math.Log((1 / value) + Math.Sqrt(1 / Math.Pow(value, 2) - 1), Math.E);
                        else
                            throw new ArithmeticException(String.Format("arsech is undefined at {0}!", value));
                    }
                    else
                        return 1 / Math.Cosh(value);
                case HyperFunc.COTH:
                    if (inverse)
                    {
                        if (value > 1 || value < -1)
                            return Math.Log((value + 1) / (value - 1), Math.E) / 2;
                        else
                            throw new ArithmeticException(String.Format("arcoth is undefined at {0}!", value));
                    }
                    else
                    {
                        if (value != 0)
                            return 1 / Math.Tanh(value);
                        else
                            throw new ArithmeticException("coth is undefined at 0!");
                    }
                default:
                    throw new ArgumentException("Invalid value for func!");
            }
        }
    }
}
