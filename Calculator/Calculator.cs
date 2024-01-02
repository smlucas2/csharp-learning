using System.ComponentModel;
using System.Text;

class Calculator
{

    public void run()
    {
        Operator currentOp;
        Operator? previousOp = null;
        StringBuilder currentVal = new StringBuilder();
        StringBuilder previousVal = new StringBuilder();

        while (true)
        {
            string userInput = Console.ReadLine();
            Boolean isOperator = Enum.IsDefined(typeof(Operator), userInput);

            if (isOperator)
            {
                currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);

                if (previousOp != Operator.EQ)
                {
                    if (previousVal.Length != 0)
                        currentVal = Calculate(previousVal, currentVal, previousOp);

                    previousVal.Clear();
                    previousVal.Append(currentVal.ToString());
                    currentVal.Clear();
                }

                previousOp = currentOp;
            }
            else
            {
                currentVal.Append(userInput);
                // TODO move this to logging
                Console.WriteLine($"--- [DISPLAY INPUT VALUE] {currentVal.ToString()}");
            }
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
                throw new NotImplementedException("Missing operator! This should never be reached.");
        }
        // TODO move this to logging
        Console.WriteLine($"--- [DISPLAY CALCULATED VALUE] {calculatedValue.ToString()}");
        return new StringBuilder(calculatedValue.ToString());
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
