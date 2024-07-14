namespace Calculator;

public class StringValueAttribute : Attribute
{
    public string StringValue { get; private set; }
    public StringValueAttribute(string value)
    {
        this.StringValue = value;
    }
}
