using System;
using PluginSDK;

namespace MultiDesktop
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

        public override double evaluate()
        {
            if (leftOperand == null)
                throw new ArithmeticException("Missing left operand for basic operation!");
            if (rightOperand == null)
                throw new ArithmeticException("Missing right operand for basic operation!");

            double divisor;

            switch (operation)
            {
                case BasicOp.Add:
                    return leftOperand.evaluate() + rightOperand.evaluate();
                case BasicOp.Subtract:
                    return leftOperand.evaluate() - rightOperand.evaluate();
                case BasicOp.Multiply:
                    return leftOperand.evaluate() * rightOperand.evaluate();
                case BasicOp.Divide:
                    divisor = rightOperand.evaluate();
                    if (divisor == 0)
                        throw new ArithmeticException("Cannot divide by 0!");
                    return leftOperand.evaluate() / divisor;
                case BasicOp.Modulo:
                    divisor = rightOperand.evaluate();
                    if (divisor == 0)
                        throw new ArithmeticException("Cannot divide by 0!");
                    return leftOperand.evaluate() % divisor;
                case BasicOp.Equal:
                    Variable newVar;
                    double result = 0;

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
                    object var = sharedData.retrieve(newVar.Name);
                    if (var != null)
                        var = result;
                    else
                        sharedData.store(newVar.Name, result);

                    return result;
                default:
                    throw new ArgumentException("Invalid value for operation!");
            }
        }
    }
}
