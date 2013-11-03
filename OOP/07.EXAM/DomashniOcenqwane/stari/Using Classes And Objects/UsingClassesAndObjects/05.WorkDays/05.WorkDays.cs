using System;

class WorkDays
{
    static DateTime today = DateTime.Now;

    static int CalculateWorkDays(DateTime dt)
    {
        string[] holidays = { "1/1", "3/3", "1/5", "6/5", "24/5", "6/9", "22/9", "24/12", "25/12" };
        DateTime tempdate = today;
        int sum = 0;

        if (dt.CompareTo(today) < 0)
        {
            return -1;
        }

        int addDay = 0;

        while (today.AddDays(addDay).CompareTo(dt) < 0)
        {
            if (today.AddDays(addDay).DayOfWeek.ToString() != "Sunday" && today.AddDays(addDay).DayOfWeek.ToString() != "Saturday")
            {
                if (!Contains(holidays, (today.AddDays(addDay).Day.ToString() + "/" + today.AddDays(addDay).Month.ToString())))
                {
                    sum++;
                }
            }

            addDay++;
        }

        return sum;
    }

    static bool Contains(string[] array, string dayOfMonth)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].CompareTo(dayOfMonth) == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        // Write a method that calculates the number of workdays between today and given date, 
        // passed as parameter. Consider that workdays are all days from Monday to Friday except 
        // a fixed list of public holidays specified preliminary as array.

        Console.Write("To calculate workdays, enter date in format month/day/year: ");
        string input = Console.ReadLine();
        DateTime dateTime = Convert.ToDateTime(input);

        if (CalculateWorkDays(dateTime) < 0)
        {
            Console.WriteLine("You have entered a day in the past!");
        }
        else
        {
            Console.WriteLine("There are {0} work days from today till {1:MM/dd/yy}", CalculateWorkDays(dateTime), dateTime);
        }
    }
}