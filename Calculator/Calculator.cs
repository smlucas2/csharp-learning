using System.Text;
using System.Windows.Markup;

class Calculator
{
    //TODO convert console output to actual buttons and display (create button classes!)
    public void run()
    {
        string displayVal;
        Operator? lastOpUsed = null;
        Boolean wasLastInputNum = false;
        StringBuilder currentVal = new StringBuilder();
        StringBuilder previousVal = new StringBuilder();

        while (true)
        {
            //TODO this should come from "button presses"
            string userInput = Console.ReadLine();

            Boolean isOp = Enum.IsDefined(typeof(Operator), userInput);
            if (isOp)
            {
                Operator currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);
                displayVal = OperatorEntered(currentOp, currentVal, previousVal, wasLastInputNum, lastOpUsed);
                //we only care about the "last operator used" if it can be used in calculations
                if (currentOp != Operator.C && currentOp != Operator.CE && currentOp != Operator.PM)
                    lastOpUsed = currentOp;
                wasLastInputNum = false;
            }
            else if (ValidValue(currentVal))
            {
                displayVal = NumberEntered(userInput, currentVal, wasLastInputNum, lastOpUsed);
                wasLastInputNum = true;
            }
            else
                displayVal = "ERR";

            Display(displayVal);
        }
    }

    private Boolean ValidValue(StringBuilder currentVal)
    {
        string valStr = currentVal.ToString();
        int length = valStr.Length;

        //our calculator will only allow up to 8 digits (excluding decimal point)
        Boolean validLength = false;
        if ((valStr.Contains('.') && length <= 8) || length <= 7)
            validLength = true;

        //our calculator will only allow up to 3 decimal places
        Boolean validDecimals = false;
        if (!valStr.Contains(".") || valStr.Split('.')[1].Length < 3)
            validDecimals = true;

        return validLength && validDecimals;
    }

    private string OperatorEntered(Operator currentOp, StringBuilder currentVal, StringBuilder previousVal, Boolean wasLastInputNum, Operator? lastOpUsed)
    {
        switch (currentOp)
        {
            case Operator.C:
            case Operator.CE:
                return HandleCCE(currentOp, currentVal, previousVal);
            case Operator.PM:
                return HandlePM(currentVal);
            default:
                return HandleArithmetic(currentVal, previousVal, wasLastInputNum, lastOpUsed);
        }
    }

    private string HandleCCE(Operator currentOp, StringBuilder currentVal, StringBuilder previousVal)
    {
        if (currentOp == Operator.CE)
            previousVal.Clear();
        currentVal.Clear();
        return "";
    }

    private string HandlePM(StringBuilder currentVal)
    {
        decimal numToInvert = Decimal.Parse(currentVal.ToString());
        currentVal.Clear();
        currentVal.Append((numToInvert * -1).ToString());
        return currentVal.ToString();
    }

    private string HandleArithmetic(StringBuilder currentVal, StringBuilder previousVal, Boolean wasLastInputNum, Operator? lastOpUsed)
    {
        if (lastOpUsed == Operator.EQ && !wasLastInputNum)
        {
            currentVal.Clear();
            return previousVal.ToString();
        }
        else if (wasLastInputNum)
        {
            if (previousVal.Length != 0)
                currentVal = Calculate(previousVal, currentVal, lastOpUsed);

            previousVal.Clear();
            previousVal.Append(currentVal.ToString());
            currentVal.Clear();
            return previousVal.ToString();
        }
        else
        {
            if (currentVal.Length > 0)
                return currentVal.ToString();
            else
                return previousVal.ToString();
        }
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

        //our calculator only allows up to 3 decimal places, so we will round any calculation results that exceed it
        result = decimal.Round(result, 3);
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
        CE,
        PM
    }
}
