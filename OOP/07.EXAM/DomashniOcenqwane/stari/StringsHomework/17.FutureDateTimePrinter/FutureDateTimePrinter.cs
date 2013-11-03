using System;
using System.Globalization;

public class FutureDateTimePrinter
{
    public static void Main()
    {
        Console.Write("Please enter a date: ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        Console.WriteLine("In six and a half hours it will be {0}, {1}", date.AddHours(6.5).ToString("dddd", new CultureInfo("bg-BG")), date.AddHours(6.5).ToString("dd.MM.yyyy HH:mm:ss"));
    }
}