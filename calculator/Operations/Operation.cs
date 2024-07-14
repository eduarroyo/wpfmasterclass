namespace Calculator;

public abstract class Operation
{
    protected double LeftOperator { get; private set; }
    protected double RightOperator { get; private set; }

    public Operation(double leftOperator, double rightOperator)
    {
        this.LeftOperator = leftOperator;
        this.RightOperator = rightOperator;
    }

    public abstract double Result();
}
