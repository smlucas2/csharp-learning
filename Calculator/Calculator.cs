using System.Text;

class Calculator
{
    //TODO display ERR if any calculation has over 8 digits (trim down to 3 decimal places)
    //TODO add 8 digit input restriction (not including decimal marker)
    //TODO add 3 decimal place restriction on input
    //TODO add +/- button to toggle positive or negative number
    //TODO convert console output to actual buttons and display (create button classes!)
    //TODO make sure logic is condense and readable
    public void run()
    {
        string displayVal;
        Operator? lastOpUsed = null;
        Boolean wasLastInputNum = false;
        StringBuilder currentVal = new StringBuilder();
        StringBuilder previousVal = new StringBuilder();

        while (true)
        {
            string userInput = Console.ReadLine();
            ValidateInput(userInput);

            Boolean isOp = Enum.IsDefined(typeof(Operator), userInput);
            if (isOp)
            {
                Operator currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);
                displayVal = OperatorEntered(currentOp, currentVal, previousVal, wasLastInputNum, lastOpUsed);
                if (currentOp != Operator.C && currentOp != Operator.CE)
                    lastOpUsed = currentOp;
                wasLastInputNum = false;
            }
            else
            {
                displayVal = NumberEntered(userInput, currentVal, wasLastInputNum, lastOpUsed);
                wasLastInputNum = true;
            }

            Display(displayVal);
        }
    }

    private void ValidateInput(string userInput)
    {
        //TODO
    }

    private string OperatorEntered(Operator currentOp, StringBuilder currentVal, StringBuilder previousVal, Boolean wasLastInputNum, Operator? lastOpUsed)
    {
        string displayVal;

        if (currentOp == Operator.C || currentOp == Operator.CE)
        {
            if (currentOp == Operator.CE)
                previousVal.Clear();

            currentVal.Clear();
            displayVal = "";
        }
        else
        {
            if (lastOpUsed == Operator.EQ && !wasLastInputNum)
            {
                displayVal = previousVal.ToString();
                currentVal.Clear();
            }
            else if (wasLastInputNum)
            {
                if (previousVal.Length != 0)
                    currentVal = Calculate(previousVal, currentVal, lastOpUsed);

                previousVal.Clear();
                previousVal.Append(currentVal.ToString());
                displayVal = currentVal.ToString();
                currentVal.Clear();
            }
            else
            {
                if (currentVal.Length > 0)
                    displayVal = currentVal.ToString();
                else
                    displayVal = previousVal.ToString();
            }
        }

        return displayVal;
    }

    private string NumberEntered(string userInput, StringBuilder currentVal, Boolean wasLastInputNum, Operator? lastOpUsed)
    {
        if (lastOpUsed == Operator.EQ && !wasLastInputNum)
            currentVal.Clear();

        currentVal.Append(userInput);
        return currentVal.ToString();
    }

    private StringBuilder Calculate(StringBuilder previousVal, StringBuilder currentVal, Operator? lastOpUsed)
    {
        decimal result;
        decimal x = Decimal.Parse(previousVal.ToString());
        decimal y = Decimal.Parse(currentVal.ToString());

        switch (lastOpUsed)
        {
            case Operator.ADD:
                result = x + y;
                break;
            case Operator.SUB:
                result = x - y;
                break;
            case Operator.MUL:
                result = x * y;
                break;
            case Operator.DIV:
                result = x / y;
                break;
            default:
                throw new NotImplementedException($"Unsupported operator for calculations.");
        }

        return new StringBuilder(result.ToString());
    }

    private void Display(string displayVal)
    {
        //TODO this should update actual display down the road
        Console.WriteLine($"                [{displayVal}]");
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
