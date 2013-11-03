using System;

public class StringToUnicodeConverter
{
    public static void Main()
    {
        string input = "Hi! What's up?";

        for (int index = 0; index < input.Length; index++)
        {
            Console.Write("\\u{0:X4}", (int)input[index]);
        }
        Console.WriteLine();
    }
}