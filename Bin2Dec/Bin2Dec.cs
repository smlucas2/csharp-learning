public class Bin2Dec
{
    public decimal ToDecimal(string bin)
    {
        checkValidBinary(bin);
        return Convert.ToInt64(bin, 2);
    }

    private void checkValidBinary(string bin)
    {
        if (bin == null || bin.Length > 8)
            throw new ArgumentException("You must input up to 8 binary digits.");

        foreach (char c in bin)
        {
            if (c < '0' || c > '1')
                throw new ArgumentException("Not a valid binary value. Values other than 1's or 0's were found.");
        }
    }
}
