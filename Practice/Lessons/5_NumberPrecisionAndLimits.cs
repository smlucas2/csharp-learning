public class NumberPrecisionAndLimits
{
    public static void Test()
    {
        int a = 7;
        int b = 4;
        int c = 3;
        int d = (a + b) / c;
        int e = (a + b) % c;
        Console.WriteLine($"quotient: {d}");
        Console.WriteLine($"remainder: {e}");

        int maxInt = int.MaxValue;
        int minInt = int.MinValue;
        Console.WriteLine($"The range of integers is {minInt} to  {maxInt}");

        int overflow = maxInt + 4;
        Console.WriteLine($"An example of overflow: {overflow}");

        double ax = 5;
        double bx = 4;
        double cx = 2;
        double dx = (ax + bx) / cx;
        Console.WriteLine(dx);

        double maxDub = double.MaxValue;
        double minDub = double.MinValue;
        Console.WriteLine($"The range of the double type is {maxDub} to  {minDub}");

        double third = 1.0 / 3.0;
        Console.WriteLine(third);

        decimal maxDec = decimal.MaxValue;
        decimal minDec = decimal.MinValue;
        Console.WriteLine($"The range of the decimal type is {maxDec} to {minDec}");

        double ay = 1.0;
        double by = 3.0;
        Console.WriteLine(ay / by);

        decimal cy = 1.0M;
        decimal dy = 3.0M;
        Console.WriteLine(cy / dy);

        long minLong = long.MinValue;
        long maxLong = long.MaxValue;
        Console.WriteLine($"The range of the long type is {minLong} to {maxLong}");

        short minShort = short.MinValue;
        short maxShort = short.MaxValue;
        Console.WriteLine($"The range of the short type is {minShort} to {maxShort}");

        double radius = 2.50;
        double area = Math.PI * radius * radius;
        Console.WriteLine(area);
    }
}
