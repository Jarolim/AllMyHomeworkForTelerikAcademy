using System;

public class TimeLapseCalculator
{
    public static void Main()
    {
        Console.Write("Please enter the first date: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Please enter the second date: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("There are {0} days between the two dates.", Math.Abs((firstDate - secondDate).Days));
    }
}