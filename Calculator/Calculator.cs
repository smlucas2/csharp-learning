using System.IO;
using System.Text;

class Calculator
{
    private string displayValue = "";
    //TODO add file path to log file, use same location as Calculator.cs
    private string logFilePath = "";
    //TODO add user inputs, calculations, etc to log as calculator runs!
    private StringBuilder log = new StringBuilder();

    //TODO fix performing a new calculation directly after pressing EQ not working correctly
    //TODO add logging
    //TODO move bulk of logic outside of run method and break apart to make more readable. run should be a lower level method
    //TODO display ERR if any calculation has over 8 digits (trim down to 3 decimal places)
    //TODO add 8 digit input restriction (not including decimal marker)
    //TODO add 3 decimal place restriction on input
    //TODO add +/- button to toggle positive or negative number
    //TODO convert console output to actual buttons and display (create button classes!)
    //TODO make sure logic is condense and readable
    public void run()
    {
        Boolean opPreviouslyUsed = false;
        StringBuilder currentVal = new StringBuilder();
        StringBuilder previousVal = new StringBuilder();
        Operator currentOp;
        Operator? previousOp = null;

        while (true)
        {
            string userInput = Console.ReadLine();
            Boolean isOperator = Enum.IsDefined(typeof(Operator), userInput);

            if (isOperator)
            {
                currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);

                if (currentOp == Operator.C || currentOp == Operator.CE)
                {
                    if (currentOp == Operator.CE)
                    {
                        previousVal.Clear();
                        previousOp = null;
                    }
                    currentVal.Clear();
                    this.displayValue = "";
                    opPreviouslyUsed = false;
                }
                else
                {
                    if (previousOp != Operator.EQ && !opPreviouslyUsed)
                    {
                        if (previousVal.Length != 0)
                            currentVal = Calculate(previousVal, currentVal, previousOp);

                        previousVal.Clear();
                        previousVal.Append(currentVal.ToString());
                        currentVal.Clear();
                    }

                    previousOp = currentOp;
                    opPreviouslyUsed = true;
                }
            }
            else
            {
                currentVal.Append(userInput);
                opPreviouslyUsed = false;
                this.displayValue = currentVal.ToString();
            }

            Display();
            Log();
        }
    }

    private StringBuilder Calculate(StringBuilder previousValue, StringBuilder currentValue, Operator? op)
    {
        decimal calculatedValue;
        decimal pValue = Decimal.Parse(previousValue.ToString());
        decimal cValue = Decimal.Parse(currentValue.ToString());

        switch (op)
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
                throw new NotImplementedException($"Unsupported operator for calculations: {op.ToString()}");
        }

        this.displayValue = calculatedValue.ToString();
        return new StringBuilder(calculatedValue.ToString());
    }

    private void Display()
    {
        Console.WriteLine($"                [{this.displayValue}]");
    }

    private void Log()
    {
        File.WriteAllText(this.logFilePath + "log.txt", this.log.ToString());
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
