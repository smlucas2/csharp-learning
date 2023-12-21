class Bin2DecTests
{
    private static Bin2Dec bin2Dec = new Bin2Dec();

    public static void Main(string[] args)
    {
        testValidValue();
        testOnly1sAnd0s();
        testMax8Length();
    }

    private static void testValidValue()
    {
        decimal? output = null;
        try
        {
            output = bin2Dec.ToDecimal("01011001");
        } catch (ArgumentException)
        {
            Console.WriteLine("Valid Value test FAILED.");
            return;
        }
        Console.WriteLine($"Valid Value test PASSED with output of {output}.");
    }

    private static void testOnly1sAnd0s()
    {
        try
        {
            bin2Dec.ToDecimal("345001");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Only 1s And 0s test PASSED.");
            return;
        }
        Console.WriteLine("Only 1s And 0s test FAILED.");
    }

    private static void testMax8Length()
    {
        try
        {
            bin2Dec.ToDecimal("0100111010101");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Max 8 Length Test PASSED.");
            return;
        }
        Console.WriteLine("Max 8 Length Test FAILED.");
    }
}