public class ArraysListsCollections
{
    public static void Test()
    {
        var names = new List<string> { "Sean" };
        foreach (var name in names)
            Console.WriteLine($"Hello {name.ToUpper()}!");

        for (int i = 0; i < 1; i++)
            Console.WriteLine($"Hello {names[i].ToUpper()}!");

        var names2 = new List<string> { "Sean", "Kate", "Wendy" };
        names2.Add("Robert");
        names2.Add("Patrick");
        names2.Remove("Sean");
        foreach (var name in names2)
        {
            Console.WriteLine(name);
        }

        var index = names2.IndexOf("Kate");
        if (index == -1)
            Console.WriteLine("Not found");
        else
            Console.WriteLine($"Name " + names2[index] + " Found at {index}");

        var names3 = new List<string> { "Sean" };
        names3.Add("Maria");
        names3.Add("Bill");
        names3.Sort();
        foreach (var name in names3)
        {
            Console.WriteLine(name);
        }

        var fibonacciNumbers = new List<int> { 1, 1 };
        while(fibonacciNumbers.Count < 20)
        { 
            var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
            var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
            fibonacciNumbers.Add(previous + previous2);
            foreach (var number in fibonacciNumbers)
                Console.WriteLine($"{number}");
        }
    }
}

