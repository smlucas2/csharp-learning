using System.ComponentModel;
using System.Text;

class Calculator
{
    private StringBuilder previousValue = new StringBuilder();
    private StringBuilder currentValue = new StringBuilder();
    private Operator? previousOperation = null;

    public Calculator() { }

    public void run()
    {
        // we will assume userInput will only be numbers or operators as we intend to use buttons later
        while (true)
        {
            string userInput = Console.ReadLine();
            Boolean isOperator = Enum.IsDefined(typeof(Operator), userInput);
            if (isOperator)
            {
                Operator userOperator = (Operator)Enum.Parse(typeof(Operator), userInput);
                if (userOperator == Operator.EQ)
                {
                    decimal calculatedValue = this.previousValue.Length > 0 ? CalculateValue() : Decimal.Parse(this.currentValue.ToString());
                    this.previousValue.Clear();
                    this.previousValue.Append(calculatedValue.ToString());
                    this.previousOperation = null;
                }
                else
                {
                    if (this.previousOperation == null)
                        this.previousValue.Append(this.currentValue.ToString());
                    else
                    {
                        decimal calculatedValue = CalculateValue();
                        this.previousValue.Clear();
                        this.previousValue.Append(calculatedValue.ToString());
                    }
                    this.previousOperation = userOperator;
                }
                this.currentValue.Clear();
            }
            else
            {
                this.currentValue.Append(userInput);
                // TODO move this to logging
                Console.WriteLine($"[DISPLAY INPUT VALUE] {this.currentValue.ToString()}");
            }
        }
    }

    private decimal CalculateValue()
    {
        decimal calculatedValue;
        decimal pValue = Decimal.Parse(this.previousValue.ToString());
        decimal cValue = Decimal.Parse(this.currentValue.ToString());
        switch (this.previousOperation)
        {
            case Operator.ADD:
                calculatedValue = pValue + cValue;
                break;
            case Operator.SUB:
                calculatedValue = pValue - cValue;
                break;
            case Operator.MUL:
                calculatedValue = pValue * cValue;
                break;
            case Operator.DIV:
                calculatedValue = pValue / cValue;
                break;
            default:
                throw new NotImplementedException("Missing operator! This should never be reached.");
        }
        // TODO move this to logging
        Console.WriteLine($"[DISPLAY CALCULATED VALUE] {calculatedValue.ToString()}");
        return calculatedValue;
    }

    private enum Operator
    {
        ADD, 
        SUB, 
        MUL, 
        DIV,
        EQ
    }
}
