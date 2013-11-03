using System;

public class VariousFormatsPrinter
{
    public static void Main()
    {
        // int input = int.Parse(Console.ReadLine());
        int input = 7489;

        Console.WriteLine("{0, 15:D}", input);
        Console.WriteLine("{0, 15:X}", input);
        Console.WriteLine("{0, 15:P}", input);
        Console.WriteLine("{0, 15:E}", input);
    }
}