using System;

class LeapYear
{
    static bool IsLeapYear(int year)
    {
        if (DateTime.IsLeapYear(year))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        // Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

        Console.Write("Enter a year to check is it leap: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("{0} is {1}a leap year.", year, IsLeapYear(year) ? "" : "not ");
    }
}