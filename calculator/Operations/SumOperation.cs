namespace Calculator;

public class SumOperation : Operation
{
    public SumOperation(double leftOperator, double rightOperator) : base(leftOperator, rightOperator)
    {
    }

    public override double Result()
    {
        return LeftOperator + RightOperator;
    }
}
