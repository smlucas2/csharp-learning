using Calculator;
using System.Reflection;
using System.Runtime.CompilerServices;

class CalculatorTests
{
    [STAThread]
    public static void Main(string[] args)
    {
        System.Windows.Application app = new System.Windows.Application();
        app.Run(new Window1());
    }
}