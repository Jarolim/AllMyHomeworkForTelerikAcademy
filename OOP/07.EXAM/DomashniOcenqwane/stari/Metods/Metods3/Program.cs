using System;

class Program
{
    static string PrintWordNum(int number)
    {
        number = number % 10;

        string[] numbers = { "Null", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        return numbers[number];
    }

    static void Main()
    {
        Console.WriteLine("Enter Number:");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine(PrintWordNum(num));
    }
}
