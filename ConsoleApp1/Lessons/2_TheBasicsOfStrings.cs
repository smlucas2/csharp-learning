public class WorkWithStrings
{
    public static void Test()
    {
        string firstFriend = "Maria";
        string secondFriend = "Sage";
        Console.WriteLine($"My Friends are {firstFriend} and {secondFriend}");

        Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters");
        Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters");

        string greeting = "     Hello World!     ";
        Console.WriteLine($"[{greeting}]");

        string trimmedGreeting = greeting.TrimStart();
        Console.WriteLine($"[{trimmedGreeting}]");

        trimmedGreeting = greeting.TrimEnd();
        Console.WriteLine($"[{trimmedGreeting}]");

        trimmedGreeting = greeting.Trim();
        Console.WriteLine($"[{trimmedGreeting}]");

        string sayHello = "Hello World!";
        Console.WriteLine(sayHello);

        sayHello = sayHello.Replace("Hello", "Greetings");
        Console.WriteLine(sayHello);

        Console.WriteLine(sayHello.ToUpper());
        Console.WriteLine(sayHello.ToLower());
    }
}