public class BranchesAndLoops
{
    public static void Test()
    {
        int a = 5;
        int b = 6;
        if (a + b > 10)
            Console.WriteLine("The answer is greater than 10");
        else
            Console.WriteLine("The answer is not greater than 10");

        int c = 4;
        if ((a + b + c > 10) || (a == b))
        {
            Console.WriteLine("The answer is greater than 10");
            Console.WriteLine("And the first number is equal to the second");
        }
        else
        {
            Console.WriteLine("The answer is not greater than 10");
            Console.WriteLine("Or the first number is equal to the second");
        }

        int counterWhile = 0;
        while (counterWhile < 10) {
            Console.WriteLine($"The counter is {counterWhile}");
            counterWhile++;
        }

        int counterDo = 0;
        do
        {
            Console.WriteLine($"The counter is {counterDo}");
        } while (counterDo < 10);

        for (int i = 0; i < 0; i++)
        {
            Console.WriteLine($"The index is {i}");
        }

        int sum = 0;
        for (int i = 0; i <= 20; i++)
        {
            if (i % 3 == 0)
            {
                sum += i;
            }
        }
        Console.WriteLine($"The sum is {sum}");
    }
}

