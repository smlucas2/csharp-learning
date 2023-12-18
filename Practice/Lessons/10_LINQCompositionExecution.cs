public class LINQCompositionExecution
{
    public static void Test()
    {
        var wordsA = new string[] { "cherry", "apple", "blueberry" };
        var wordsB = new string[] { "cherry", "apple", "blueberry" };
        bool match1 = wordsA.SequenceEqual(wordsB);
        Console.WriteLine($"The sequences match: {match1}");

        var wordsC = new string[] { "blueberry", "apple", "cherry" };
        var wordsD = new string[] { "cherry", "apple", "blueberry" };
        bool match2 = wordsA.SequenceEqual(wordsB);
        Console.WriteLine($"The sequences match: {match2}");

        int[] vectorA = { 0, 2, 4, 5, 6 };
        int[] vectorB = { 1, 3, 5, 7, 8 };
        var zipped = vectorA.Zip(vectorB, (a, b) => a * b);
        Console.WriteLine("Multiplying values from 2 arrays.");
        foreach (var num in zipped)
        {
            Console.WriteLine(num);
        }

        int[] numsA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numsB = { 1, 3, 5, 7, 8 };
        var pairs = from a in numsA
                    from b in numsB
                    where a < b
                    select (a, b);
        Console.WriteLine("Pairs where a < b");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.a} is less than {pair.b}");
        }

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var lowNumber = from n in numbers
                        where n <= 3
                        select n;
        Console.WriteLine("First run numbers >= 3:");
        foreach (int n in lowNumber)
        {
            Console.WriteLine(n);
        }
        //changing the values
        for (int i = 0; i< 10; i++)
        {
            numbers[i] = -numbers[i];
        }
        Console.WriteLine("Second run numbers >= 3:");
        foreach (int n in lowNumber)
        {
            Console.WriteLine(n);
        }
    }
}
