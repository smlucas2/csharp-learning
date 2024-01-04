using System.Text;

class Calculator
{
    Boolean usedEQ = false;
    Boolean usedC = false;
    Boolean usedCE = false;
    Boolean usedOP = false;

    //TODO implement new boolean flags
    //TODO display ERR if any calculation has over 8 digits (trim down to 3 decimal places)
    //TODO add 8 digit input restriction (not including decimal marker)
    //TODO add 3 decimal place restriction on input
    //TODO add +/- button to toggle positive or negative number
    //TODO convert console output to actual buttons and display (create button classes!)
    //TODO make sure logic is condense and readable
    public void run()
    {
        string displayValue = "";
        StringBuilder currentVal = new StringBuilder();
        StringBuilder previousVal = new StringBuilder();

        while (true)
        {
            string userInput = Console.ReadLine();

            Boolean isOperator = Enum.IsDefined(typeof(Operator), userInput);
            if (isOperator)
                displayValue = OperatorEntered(userInput, currentVal, previousVal);
            else
                displayValue = ValueEntered(userInput, currentVal);

            Display(displayValue);
        }
    }

    private string OperatorEntered(string userInput, StringBuilder currentVal, StringBuilder previousVal)
    {
        string displayValue;

        Operator currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);
        if (currentOp == Operator.C || currentOp == Operator.CE)
        {
            if (currentOp == Operator.CE)
            {
                previousVal.Clear();
                this.previousOp = null;
            }

            currentVal.Clear();
            this.lastInputWasOp = false;
            displayValue = "";
        }
        else
        {
            if (this.previousOp != Operator.EQ && !this.lastInputWasOp)
            {
                if (previousVal.Length != 0)
                    currentVal = Calculate(previousVal, currentVal);

                previousVal.Clear();
                previousVal.Append(currentVal.ToString());
                displayValue = currentVal.ToString();
                currentVal.Clear();
            }
            else if (this.previousOp == Operator.EQ)
            {
                displayValue = previousVal.ToString();
                currentVal.Clear();
            }
            else
                displayValue = currentVal.ToString();

            this.previousOp = currentOp;
            this.lastInputWasOp = true;
        }

        return displayValue;
    }

    private string ValueEntered(string userInput, StringBuilder currentVal)
    {
        if (this.previousOp == Operator.EQ)
            currentVal.Clear();

        currentVal.Append(userInput);
        this.lastInputWasOp = false;
        return currentVal.ToString();
    }

    private StringBuilder Calculate(StringBuilder previousValue, StringBuilder currentValue)
    {
        decimal calculatedValue;
        decimal pValue = Decimal.Parse(previousValue.ToString());
        decimal cValue = Decimal.Parse(currentValue.ToString());

        switch (this.previousOp)
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
                throw new NotImplementedException($"Unsupported operator for calculations.");
        }

        return new StringBuilder(calculatedValue.ToString());
    }

    private void Display(string displayValue)
    {
        //TODO this should update actual display down the road
        Console.WriteLine($"                [{displayValue}]");
    }

    private enum Operator
    {
        ADD, 
        SUB, 
        MUL, 
        DIV,
        EQ,
        C,
        CE
    }
}
