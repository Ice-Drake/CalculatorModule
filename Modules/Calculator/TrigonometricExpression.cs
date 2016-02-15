using System;

namespace MultiDesktop
{
    public enum TrigFunc
    {
        SIN,
        COS,
        TAN,
        CSC,
        SEC,
        COT,
    }

    public class TrigonometricExpression : SingleOperandExpression
    {
        public static bool Mode = false; //true for degree and false for radian

        private TrigFunc func;
        private bool inverse;

        public TrigonometricExpression(TrigFunc func, bool inverse = false)
        {
            this.func = func;
            this.inverse = inverse;
            leftAssociative = false;
            precedence = 3;
        }

        public override Numeral evaluate()
        {
            if (operand == null)
                throw new ArithmeticException("Missing operand for trigonometric function!");

            Numeral numeral = operand.evaluate();

            if (numeral.GetType() == typeof(RealNumber))
            {
                double value = ((RealNumber)numeral).getValue();

                //Convert to radians if it is in degree mode and it is not an inverse function
                if (Mode && !inverse)
                    value = value * Math.PI / 180;

                double result = 0;

                switch (func)
                {
                    case TrigFunc.SIN:
                        if (inverse)
                        {
                            if (value <= 1 && value >= -1)
                                result = Math.Asin(value);
                            else
                                throw new ArithmeticException(String.Format("arcsin is undefined at {0}!", value));
                        }
                        else
                            result = Math.Sin(value);
                        break;
                    case TrigFunc.COS:
                        if (inverse)
                        {
                            if (value <= 1 && value >= -1)
                                result = Math.Acos(value);
                            else
                                throw new ArithmeticException(String.Format("arccos is undefined at {0}!", value));
                        }
                        else
                            result = Math.Cos(value);
                        break;
                    case TrigFunc.TAN:
                        if (inverse)
                            result = Math.Atan(value);
                        else
                        {
                            if (Math.Abs(value % Math.PI) != Math.PI / 2)
                                result = Math.Tan(value);
                            else
                                throw new ArithmeticException(String.Format("tan is undefined at {0}!", value));
                        }
                        break;
                    case TrigFunc.CSC:
                        if (inverse)
                        {
                            if (value <= -1 || value >= 1)
                                result = Math.Asin(1 / value);
                            else
                                throw new ArithmeticException(String.Format("arccsc is undefined at {0}!", value));
                        }
                        else
                        {
                            if (value % Math.PI != 0)
                                result = 1 / Math.Sin(value);
                            else
                                throw new ArithmeticException(String.Format("csc is undefined at {0}!", value));
                        }
                        break;
                    case TrigFunc.SEC:
                        if (inverse)
                        {
                            if (value <= -1 || value >= 1)
                                result = Math.Acos(1 / value);
                            else
                                throw new ArithmeticException(String.Format("arcsec is undefined at {0}!", value));
                        }
                        else
                        {
                            if (Math.Abs(value % Math.PI) != Math.PI / 2)
                                result = 1 / Math.Cos(value);
                            else
                                throw new ArithmeticException(String.Format("sec is undefined at {0}!", value));
                        }
                        break;
                    case TrigFunc.COT:
                        if (inverse)
                            result = Math.PI / 2 - Math.Atan(value);
                        else
                        {
                            if (value % Math.PI != 0)
                                result = Math.Cos(value) / Math.Sin(value);
                            else
                                throw new ArithmeticException(String.Format("cot is undefined at {0}!", value));
                        }
                        break;
                }

                //Convert to degree if it is in degree mode and it is an inverse function
                if (Mode && inverse)
                    result = result * 180 / Math.PI;

                return new RealNumber(result);
            }
            else
                throw new ArithmeticException(String.Format("Cannot perform trigonmetric function on {0}!", numeral.TypeName.ToLower()));
        }
    }
}
