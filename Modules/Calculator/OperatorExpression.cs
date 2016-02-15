using System;

namespace MultiDesktop
{
    public abstract class OperatorExpression : Expression, IComparable
    {
        protected bool leftAssociative;
        protected int precedence;

        public int CompareTo(object obj)
        {
            if (!(obj is OperatorExpression))
                throw new ArgumentException("The object being compared to is not the same type as this instance!");

            return ((OperatorExpression)obj).precedence - precedence + (leftAssociative ? 1 : 0);
        }

        public abstract Numeral evaluate();
    }
}
