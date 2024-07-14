namespace Calculator;

internal static class OperationFactory
{
    public static Operation BuildOperation(double leftOperator, double rightOperator, EOperation operation)
    {
        return operation switch
        {
            EOperation.Sum => new SumOperation(leftOperator, rightOperator),
            EOperation.Substract => new SubstractOperation(leftOperator, rightOperator),
            EOperation.Multiply => new MultiplyOperation(leftOperator, rightOperator),
            EOperation.Divide => new DivideOperation(leftOperator, rightOperator),
            _ => throw new ArgumentException("Invalid operation", operation.ToString())
        };
    }
}
