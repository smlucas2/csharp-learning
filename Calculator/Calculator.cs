using System.ComponentModel;
using System.Text;

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
            // TODO figure out how to launch the console and allow user input
            string userInput = Console.ReadLine();
            if (Enum.IsDefined(typeof(Operator), userInput))
            {
                if (this.operation == null && this.operation != Operator.EQ)
                {
                    this.operation = (Operator) Enum.Parse(typeof(Operator), userInput);
                    this.previousValue.Append(this.currentValue.ToString());
                    this.currentValue.Clear();
                }
                else
                {
                    decimal calculatedValue = CalculateValue();
                    this.previousValue.Clear();
                    this.previousValue.Append(calculatedValue.ToString());
                    Console.WriteLine(calculatedValue.ToString());
                    if (this.operation == Operator.EQ)
                        break;
                }
            }
            else
                this.currentValue.Append(userInput);
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
