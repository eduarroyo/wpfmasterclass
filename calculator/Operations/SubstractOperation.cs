namespace Calculator;

public class SubstractOperation : Operation
{
    public SubstractOperation(double leftOperator, double rightOperator) : base(leftOperator, rightOperator)
    {
    }

    public override double Result()
    {
        return LeftOperator - RightOperator;
    }
}
