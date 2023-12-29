using System.ComponentModel;
using System.Text;

//FIXME after hitting EQ, the next operation fails
class Calculator
{
    private StringBuilder previousValue = new StringBuilder();
    private StringBuilder currentValue = new StringBuilder();
    private Operator? operation = null;

    public Calculator() { }

    public void run()
    {
        // we will assume userInput will only be numbers or operators as we intend to use buttons later
        while (true)
        {
            string userInput = Console.ReadLine();
            if (Enum.IsDefined(typeof(Operator), userInput))
            {
                Operator userOperator = (Operator)Enum.Parse(typeof(Operator), userInput);
                if (userOperator == Operator.EQ)
                {
                    decimal calculatedValue;
                    if (this.previousValue.Length > 0)
                        calculatedValue = CalculateValue();
                    else
                        calculatedValue = Decimal.Parse(this.currentValue.ToString());
                    // TODO move this to logging
                    Console.WriteLine($"[DISPLAY] {calculatedValue.ToString()}");
                    this.previousValue.Clear();
                    this.currentValue.Clear();
                }
                else
                {
                    if (this.operation == null)
                    {
                        this.operation = userOperator;
                        this.previousValue.Append(this.currentValue.ToString());
                        this.currentValue.Clear();
                    }
                    else
                    {
                        decimal calculatedValue = CalculateValue();
                        this.operation = userOperator;
                        // TODO move this to logging
                        Console.WriteLine($"[DISPLAY] {calculatedValue.ToString()}");
                        this.previousValue.Clear();
                        this.previousValue.Append(calculatedValue.ToString());
                        this.currentValue.Clear();

                    }
                }
            }
            else
            {
                this.currentValue.Append(userInput);
                // TODO move this to logging
                Console.WriteLine($"[DISPLAY] {this.currentValue.ToString()}");
            }
        }
    }

    private decimal CalculateValue()
    {
        decimal pValue = Decimal.Parse(this.previousValue.ToString());
        decimal cValue = Decimal.Parse(this.currentValue.ToString());
        switch (this.operation)
        {
            case Operator.ADD:
                return pValue + cValue;
            case Operator.SUB:
                return pValue - cValue;
            case Operator.MUL:
                return pValue * cValue;
            case Operator.DIV:
                return pValue / cValue;
            default:
                throw new NotImplementedException("Missing operator! This should never be reached.");
        }
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
