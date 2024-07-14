using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double? leftOperator = null;
    EOperation? operation = null;
    bool newValue = true;

    public MainWindow()
    {
        InitializeComponent();
        ACButton.Click += ACButton_Click;
        NegativeButton.Click += NegativeButton_Click;
        NumberOneButton.Click += NumberButton_Click;
        NumberTwoButton.Click += NumberButton_Click;
        NumberThreeButton.Click += NumberButton_Click;
        NumberFourButton.Click += NumberButton_Click;
        NumberFiveButton.Click += NumberButton_Click;
        NumberSixButton.Click += NumberButton_Click;
        NumberSevenButton.Click += NumberButton_Click;
        NumberEightButton.Click += NumberButton_Click;
        NumberNineButton.Click += NumberButton_Click;
        NumberZeroButton.Click += NumberButton_Click;
        SumButton.Click += OperationButton_Click;
        SubstractButton.Click += OperationButton_Click;
        MultiplyButton.Click += OperationButton_Click;
        DivideButton.Click += OperationButton_Click;
        EqualButton.Click += EqualButton_Click;
    }

    #region Buttons Event Handlers
    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        if (leftOperator != null && operation != null)
        {
            double rightOperator = CurrentNumericValue();
            Operation op = OperationFactory.BuildOperation(leftOperator.Value, rightOperator, operation.Value);
            double result = op.Result();
            SetCurrentValue(result);
            newValue = true;
        }
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        leftOperator = CurrentNumericValue();
        operation = ((Button)sender).Content switch
        {
            "+" => EOperation.Sum,
            "-" => EOperation.Substract,
            "*" => EOperation.Multiply,
            "/" => EOperation.Divide,
            _ => null
        };
        newValue = true;
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        double currentValue = CurrentNumericValue();
        string strDigit = ((Button)sender).Content.ToString() ?? "0";
        int digit = int.Parse(strDigit);
        if(newValue)
        {
            SetCurrentValue(digit);
            newValue = false;
        }
        else
        {
            PushDigit(digit);
        }
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
        double currentValue = CurrentNumericValue();
        if(currentValue != 0)
        {
            currentValue = -1* currentValue;
            resultLabel.Content = currentValue.ToString();
        }
    }

    private void ACButton_Click(object sender, RoutedEventArgs e)
    {
        SetCurrentValue(0D);
        leftOperator = null;
        operation = null;
        newValue = true;
    }

    #endregion

    private double CurrentNumericValue()
    {
        string currentValueStr = CurrentStringValue();
        if (double.TryParse(currentValueStr, out double currentValue))
        {
            return currentValue;
        }
        return 0D;
    }

    private string CurrentStringValue()
    {
        return resultLabel.Content.ToString() ?? "0";
    }

    private void SetCurrentValue(double value)
    {
        this.resultLabel.Content = value.ToString(CultureInfo.InvariantCulture);
    }

    private void PushDigit(int digit)
    {
        string currentValue = CurrentStringValue();
        this.resultLabel.Content = $"{currentValue}{digit}";
    }
}