using System;

class DayOfWeek
{
    static string GetDayOfWeek(DateTime dateTime)
    {
        return dateTime.DayOfWeek.ToString();
    }

    static void Main()
    {
        //Write a program that prints to the console which day of the week is today. Use System.DateTime.

        DateTime dateTime = DateTime.Now;
        Console.WriteLine("Today is {0}", GetDayOfWeek(dateTime));
    }
}