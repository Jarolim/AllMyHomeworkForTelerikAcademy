using System;

public class LimitedLengthStringPrinter
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(input.Length >= 20 ? input.Substring(0, 20) : input + new string('*', 20 - input.Length));
    }
}