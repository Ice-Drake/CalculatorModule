using PluginSDK;

namespace CalculatorModule
{
    public abstract class TwoOperandExpression : OperatorExpression
    {
        protected Expression leftOperand;
        protected Expression rightOperand;

        public void setLeftOperand(Expression operand)
        {
            leftOperand = operand;
        }

        public void setRightOperand(Expression operand)
        {
            rightOperand = operand;
        }
    }
}
