public class LINQIntroduction
{
    public static void Test()
    {
        List<int> digits = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var lowNums = from num in digits where num < 5 select num;
        foreach (var num in lowNums)
        {
            Console.WriteLine(num);
        }

        string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        var shortDigits = strings.Where((digits, index) => digits.Length < index);
        foreach (var digit in shortDigits)
        {
            Console.WriteLine($"The word {digit} is shorter th an its value.");
        }

        var textNums = from n in digits
                       select strings[n];
        foreach (var num in textNums)
        {
            Console.WriteLine(num);
        }
    }
        
}
