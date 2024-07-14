namespace Calculator;

public class MultiplyOperation : Operation
{
    public MultiplyOperation(double leftOperator, double rightOperator) : base(leftOperator, rightOperator)
    {
    }

    public override double Result()
    {
        return LeftOperator * RightOperator;
    }
}
