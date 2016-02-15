namespace MultiDesktop
{
    public abstract class SingleOperandExpression : OperatorExpression
    {
        protected Expression operand;

        public void setOperand(Expression operand)
        {
            this.operand = operand;
        }
    }
}
