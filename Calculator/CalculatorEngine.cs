﻿using System.Text;

class CalculatorEngine
{
    private Operator? lastOpUsed = null;
    private Boolean wasLastInputNum = false;
    private StringBuilder currentVal = new StringBuilder();
    private StringBuilder previousVal = new StringBuilder();

    public string Input(string userInput)
    {
        string displayVal;

        Boolean isOp = Enum.IsDefined(typeof(Operator), userInput);
        if (isOp)
        {
            Operator currentOp = (Operator)Enum.Parse(typeof(Operator), userInput);
            displayVal = OperatorEntered(currentOp);
            //we only care about the "last operator used" if it can be used in calculations
            if (currentOp != Operator.C && currentOp != Operator.CE && currentOp != Operator.PM)
                this.lastOpUsed = currentOp;
            if (currentOp != Operator.PM)
                this.wasLastInputNum = false;
        }
        else if (ValidValue())
        {
            displayVal = NumberEntered(userInput);
            this.wasLastInputNum = true;
        }
        else
            displayVal = "ERR";

       return displayVal;
    }

    private Boolean ValidValue()
    {
        string valStr = this.currentVal.ToString();
        int length = valStr.Length;

        //the rules only allow up to 8 digits (excluding decimal point)
        Boolean validLength = false;
        if ((valStr.Contains('.') && length <= 8) || length <= 7)
            validLength = true;

        //the rules only allow up to 3 decimal places
        Boolean validDecimals = false;
        if (!valStr.Contains('.') || valStr.Split('.')[1].Length < 3)
            validDecimals = true;

        return validLength && validDecimals;
    }

    private string OperatorEntered(Operator currentOp)
    {
        switch (currentOp)
        {
            case Operator.C:
                return HandleC();
            case Operator.CE:
                return HandleCE();
            case Operator.PM:
                return HandlePM();
            default:
                return HandleArithmetic();
        }
    }

    private string HandleC()
    {
        this.currentVal.Clear();
        return "";
    }

    private string HandleCE()
    {
        this.previousVal.Clear();
        this.currentVal.Clear();
        return "";
    }

    private string HandlePM()
    {
        decimal numToInvert;
        if (this.currentVal.Length > 0)
        {
            numToInvert = Decimal.Parse(this.currentVal.ToString());
            this.currentVal.Clear();
            this.currentVal.Append((numToInvert * -1).ToString());
            return this.currentVal.ToString();
        }
        else
        {
            numToInvert = Decimal.Parse(this.previousVal.ToString());
            this.previousVal.Clear();
            this.previousVal.Append((numToInvert * -1).ToString());
            return this.previousVal.ToString();
        }
    }

    private string HandleArithmetic()
    {
        if (this.lastOpUsed == Operator.EQ && !this.wasLastInputNum)
        {
            this.currentVal.Clear();
            return this.previousVal.ToString();
        }
        else if (this.wasLastInputNum)
        {
            if (this.previousVal.Length != 0)
                this.currentVal = Calculate();

            this.previousVal.Clear();
            this.previousVal.Append(this.currentVal.ToString());
            this.currentVal.Clear();
            return this.previousVal.ToString();
        }
        else
        {
            if (this.currentVal.Length > 0)
                return this.currentVal.ToString();
            else
                return this.previousVal.ToString();
        }
    }

    private string NumberEntered(string userInput)
    {
        if (this.lastOpUsed == Operator.EQ && !this.wasLastInputNum)
            this.previousVal.Clear();

        //a number should ahve only one '.'
        if (userInput.Equals(".") && this.currentVal.ToString().Contains('.'))
            return this.currentVal.ToString();
        else
        {
            this.currentVal.Append(userInput);
            return this.currentVal.ToString();
        }
    }

    private StringBuilder Calculate()
    {
        decimal result;
        decimal x = Decimal.Parse(this.previousVal.ToString());
        decimal y = Decimal.Parse(this.currentVal.ToString());

        switch (this.lastOpUsed)
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

        //the rules only allows up to 3 decimal places, so we will round any calculation results that exceed it
        result = decimal.Round(result, 3);
        return new StringBuilder(result.ToString());
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
