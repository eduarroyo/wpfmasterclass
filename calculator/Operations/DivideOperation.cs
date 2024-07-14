namespace Calculator;

public class DivideOperation : Operation
{
    public DivideOperation(double leftOperator, double rightOperator) : base(leftOperator, rightOperator)
    {
        if(rightOperator.Equals(0))
        {
            throw new DivideByZeroException();
        }
    }

    public override double Result()
    {
        return LeftOperator / RightOperator;
    }
}