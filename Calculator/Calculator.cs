using System.ComponentModel;
using System.Text;

class Calculator
{
    /*
     * lets first be able to enter values and perform simple operations consecutively.
     * 
     * i'll start with a console app and add a display with buttons down the line
     * 
     * while entering value, record user inputs as strings and append together. Once an 
     * operation key is pressed, we are no longer entering values and the next number 
     * press will be the start of a new value. Record the operation pressed for executing
     * the operation after the next operation key is pressed
     */
    private Boolean running = true;
    private Boolean enteringValue = true;
    private StringBuilder previousValue = new StringBuilder("0");
    private StringBuilder currentValue = new StringBuilder();
    private Operator operation;

    public Calculator() { }

    public void run()
    {
        while (this.running)
        {
            // 1. enter and store 1st value in currentValue...
            // 2. enter and store operator...
            // 3. enter and store 2nd value in currentValue, move 1st value to previousValue...
            // 4. next operator is entered...
            //   calculate [1st value - 1st operator - 2nd value] and set to currentValue
            //   if EQ operator, end cycle
            //   else repeat from step 2
        }
    }

    private decimal CalculateValue()
    {
        decimal pValue = Decimal.Parse(previousValue.ToString());
        decimal cValue = Decimal.Parse(currentValue.ToString());
        switch (operation)
        {
            case Operator.ADD:
                return pValue + cValue;
            case Operator.SUB:
                return pValue - cValue;
            case Operator.MUL:
                return pValue * cValue;
            case Operator.DIV:
                return pValue / cValue;
            //TODO what about EQ?
            default:
                throw new NotImplementedException("Missing operator!");
        }
    }

    private void EnterValue(char c)
    {
        while (this.enteringValue)
            this.currentValue.Append(c);
    }
    private void ReadyNextValue(decimal calculatedValue)
    {
        this.previousValue.Clear();
        this.previousValue.Append(calculatedValue.ToString());
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
