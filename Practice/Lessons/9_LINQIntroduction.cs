public class LINQIntroduction
{
    public static void Test()
    {
        List<int> digits = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var lowNums = from num
                      in digits
                      where num < 5
                      select num;
        Console.WriteLine("Getting all digits less than 5.");
        foreach (var num in lowNums)
        {
            Console.WriteLine(num);
        }

        string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        var shortDigits = strings.Where((digits, index) => digits.Length < index);
        Console.WriteLine("Getting strings shorter than their digit length.");
        foreach (var digit in shortDigits)
        {
            Console.WriteLine($"The word {digit} is shorter the an its value.");
        }

        var textNums = from n in digits
                       select strings[n];
        Console.WriteLine("Matching number to string position.");
        foreach (var num in textNums)
        {
            Console.WriteLine(num);
        }

        var first3Numbers = digits.Take(3);
        Console.WriteLine("Getting first 3 digits.");
        foreach (var num in first3Numbers)
        {
            Console.WriteLine(num);
        }

        var lessThan9Numbers = digits.TakeWhile(i => i < 9);
        Console.WriteLine("Getting digits until one is found to be 9 or greater.");
        foreach (var num in lessThan9Numbers)
        {
            Console.WriteLine(num);
        }
    }

}
