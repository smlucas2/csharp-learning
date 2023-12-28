using System.Reflection;
using System.Runtime.CompilerServices;
class CalculatorTests
{
    private static Calculator calculator = new Calculator();

    public static void Main(string[] args)
    {
        TestCalculator();
    }

    private static void TestCalculator()
    {
        calculator.run();
    }
}