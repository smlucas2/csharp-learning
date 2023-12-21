class Bin2DecTest
{
    private static Bin2Dec bin2Dec = new Bin2Dec();

    public static void Main(string[] args)
    {
        test8Characters();
        testOnly1sAnd0s();
        testValidValue();
    }

    private static void test8Characters()
    {
        try
        {
            bin2Dec.ToDecimal("001011100100011101");
        } catch(ArgumentException)
        {
            Console.WriteLine("Test \"Only 8 characters\" PASSED");
            return;
        }
        Console.WriteLine("Test \"Only 8 characters\" FAILED");
    }

    private static void testOnly1sAnd0s()
    {
        try
        {
            bin2Dec.ToDecimal("002010a");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Test \"Only 1s and 0s\" PASSED");
            return;
        }
        Console.WriteLine("Test \"Only 1s and 0s\" FAILED");
    }
        
    private static void testValidValue()
    {
        decimal output;
        try
        {
            output = bin2Dec.ToDecimal("0010101");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Test \"Valid Value\" FAILED");
            return;
        }
        Console.WriteLine($"Test \"Valid Value\" PASSED with value {output}.");
    }
}
