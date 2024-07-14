namespace Calculator;

public class PercentageOperation : Operation
{
    public PercentageOperation(double leftOperator, double rightOperator) : base(leftOperator, rightOperator)
    {
    }

    public override double Result()
    {
        return LeftOperator * RightOperator / 100;
    }
}
