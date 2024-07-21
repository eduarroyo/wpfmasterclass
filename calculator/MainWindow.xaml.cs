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
    string? operation = null;
    bool newValue = true;
    enum ECalcStatus
    {
        Clean,
        InputLeft,
        InputRight
    }
    private ECalcStatus status = ECalcStatus.Clean;

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
        PercentageButton.Click += OperationButton_Click;
        EqualButton.Click += EqualButton_Click;
        DecimalButton.Click += DecimalButton_Click;
    }

    #region Buttons Event Handlers
    
    private void DecimalButton_Click(object sender, RoutedEventArgs e)
    {
        if(status == ECalcStatus.Clean)
        {
            resultLabel.Content = $"{resultLabel.Content}.";
            status = ECalcStatus.InputLeft;
        }
        else
        {
            string currentValue = CurrentStringValue();
            if (!currentValue.Contains('.'))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }
    }

    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        if (leftOperator != null && operation != null)
        {
            Calculate();
        }
    }

    private void Calculate()
    {
        double rightOperator = CurrentNumericValue();
        Operation op = OperationFactory.BuildOperation(leftOperator.Value, rightOperator, operation);
        double result = op.Result();
        leftOperator = result;
        SetCurrentValue(result);
        newValue = true;
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        if(leftOperator.HasValue)
        {
            Calculate();
        }
        leftOperator = CurrentNumericValue();
        operation = ((Button)sender).Content.ToString();
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
        status = ECalcStatus.Clean;
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