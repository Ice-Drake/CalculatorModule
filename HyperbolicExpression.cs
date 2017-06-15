using System;
using PluginSDK;

namespace CalculatorModule
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

        public override Numeral evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for hyperbolic function!");

            Numeral numeral = operand.evaluate();

            if (numeral.GetType() == typeof(RealNumber))
            {
                double value = ((RealNumber)numeral).getValue();

                switch (func)
                {
                    case HyperFunc.SINH:
                        return new RealNumber(inverse ? Math.Log(value + Math.Sqrt(Math.Pow(value, 2) + 1), Math.E) : Math.Sinh(value));
                    case HyperFunc.COSH:
                        return new RealNumber(inverse ? Math.Log(value + Math.Sqrt(Math.Pow(value, 2) - 1), Math.E) : Math.Cosh(value));
                    case HyperFunc.TANH:
                        return new RealNumber(inverse ? Math.Log((1 + value) / (1 - value), Math.E) / 2 : Math.Tanh(value));
                    case HyperFunc.CSCH:
                        if (inverse)
                        {
                            if (value != 0)
                                return new RealNumber(Math.Log((1 / value) + Math.Sqrt(1 + 1 / Math.Pow(value, 2)), Math.E));
                            else
                                throw new ArithmeticException("arcsch is undefined at 0!");
                        }
                        else
                        {
                            if (value != 0)
                                return new RealNumber(1 / Math.Sinh(value));
                            else
                                throw new ArithmeticException("csch is undefined at 0!");
                        }
                    case HyperFunc.SECH:
                        if (inverse)
                        {
                            if (value > 0 && value <= 1)
                                return new RealNumber(Math.Log((1 / value) + Math.Sqrt(1 / Math.Pow(value, 2) - 1), Math.E));
                            else
                                throw new ArithmeticException(String.Format("arsech is undefined at {0}!", value));
                        }
                        else
                            return new RealNumber(1 / Math.Cosh(value));
                    case HyperFunc.COTH:
                        if (inverse)
                        {
                            if (value > 1 || value < -1)
                                return new RealNumber(Math.Log((value + 1) / (value - 1), Math.E) / 2);
                            else
                                throw new ArithmeticException(String.Format("arcoth is undefined at {0}!", value));
                        }
                        else
                        {
                            if (value != 0)
                                return new RealNumber(1 / Math.Tanh(value));
                            else
                                throw new ArithmeticException("coth is undefined at 0!");
                        }
                    default:
                        throw new ArgumentException("Invalid value for func!");
                }
            }
            else
                throw new ArithmeticException(String.Format("Cannot perform trigonmetric function on {0}!", numeral.TypeName.ToLower()));
        }
    }
}
