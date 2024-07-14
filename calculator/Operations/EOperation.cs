namespace Calculator;

public enum EOperation
{
    [StringValue("+")] Sum,
    [StringValue("-")] Substract,
    [StringValue("*")] Multiply,
    [StringValue("/")] Divide,
    [StringValue("%")] Percentage
}