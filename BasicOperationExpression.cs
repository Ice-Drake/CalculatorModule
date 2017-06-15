using System;
using PluginSDK;

namespace CalculatorModule
{
    public enum BasicOp
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Modulo,
        Equal,
    }

    public class BasicOperationExpression : TwoOperandExpression
    {
        private BasicOp operation;

        public BasicOperationExpression(BasicOp operation)
        {
            this.operation = operation;
            leftAssociative = true;
            switch (operation)
            {
                case BasicOp.Add:
                case BasicOp.Subtract:
                    precedence = 1;
                    break;
                case BasicOp.Equal:
                    precedence = 0;
                    break;
                default:
                    precedence = 2;
                    break;
            }
        }

        public override Numeral evaluate()
        {
            if (leftOperand == null)
                throw new ArithmeticException("Missing left operand for basic operation!");
            if (rightOperand == null)
                throw new ArithmeticException("Missing right operand for basic operation!");

            if (operation == BasicOp.Equal)
            {
                Variable newVar;
                Numeral result = null;

                if (leftOperand.GetType() == typeof(Variable))
                {
                    newVar = (Variable)leftOperand;
                    result = rightOperand.evaluate();
                }
                else if (rightOperand.GetType() == typeof(Variable))
                {
                    newVar = (Variable)rightOperand;
                    result = leftOperand.evaluate();
                }
                else
                {
                    throw new ArithmeticException("Invalid usage of the equal operator!");
                }

                //Store variable
                SharedData sharedData = new SharedData();
                sharedData.store(newVar.Name, result);

                return result;
            }
            else
            {
                Numeral numeral1 = leftOperand.evaluate();
                Numeral numeral2 = rightOperand.evaluate();

                if (numeral1.GetType() == typeof(RealNumber) && numeral2.GetType() == typeof(RealNumber))
                {
                    double operand1 = ((RealNumber)numeral1).getValue();
                    double operand2 = ((RealNumber)numeral2).getValue();

                    switch (operation)
                    {
                        case BasicOp.Add:
                            return new RealNumber(operand1 + operand2);
                        case BasicOp.Subtract:
                            return new RealNumber(operand1 - operand2);
                        case BasicOp.Multiply:
                            return new RealNumber(operand1 * operand2);
                        case BasicOp.Divide:
                            if (operand2 == 0)
                                throw new ArithmeticException("Cannot divide by 0!");
                            return new RealNumber(operand1 / operand2);
                        case BasicOp.Modulo:
                            if (operand2 == 0)
                                throw new ArithmeticException("Cannot modulo by 0!");
                            return new RealNumber(operand1 % operand2);
                        default:
                            throw new ArgumentException("Invalid value for operation!");
                    }
                }
                else
                {
                    if (numeral1.GetType() != typeof(RealNumber))
                        throw new ArithmeticException(String.Format("Cannot perform basic operation on {0}!", numeral1.TypeName.ToLower()));
                    else
                        throw new ArithmeticException(String.Format("Cannot perform basic operation on {0}!", numeral2.TypeName.ToLower()));
                }
            }
        }
    }
}
