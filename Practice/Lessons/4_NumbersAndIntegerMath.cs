public class NumbersAndIntegerMath
{
    public static void Test()
    {
        int a = 18;
        int b = 6;

        int c = a + b;
        Console.WriteLine(c);

        c = a - b;
        Console.WriteLine(c);

        c = a * b;
        Console.WriteLine(c);

        c = a / b;
        Console.WriteLine(c);

        a = 5;
        b = 4;
        c = 2;
        int d = a + b * c;
        Console.WriteLine(d);

        d = (a + b) * c;
        Console.WriteLine(d);

        d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
        Console.WriteLine(d);

        d = (a + b) / c;
        Console.WriteLine(d);
    }
}