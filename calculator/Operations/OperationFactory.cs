namespace Calculator;

internal static class OperationFactory
{
    public static Operation BuildOperation(double leftOperator, double rightOperator, string operation)
    {
        return operation switch
        {
            "+" => new SumOperation(leftOperator, rightOperator),
            "-" => new SubstractOperation(leftOperator, rightOperator),
            "*" => new MultiplyOperation(leftOperator, rightOperator),
            "/" => new DivideOperation(leftOperator, rightOperator),
            "%" => new PercentageOperation(leftOperator, rightOperator),
            _ => throw new ArgumentException("Invalid operation", operation.ToString())
        };
    }
}
