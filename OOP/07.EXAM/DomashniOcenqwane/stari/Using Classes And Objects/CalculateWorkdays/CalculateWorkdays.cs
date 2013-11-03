/*Write a method that calculates the number of 
workdays between today and given date, passed
as parameter. Consider that workdays are all
days from Monday to Friday except a fixed list 
of public holidays specified preliminary as array.*/

using System;

class CalculateWorkdays
{
    static int Workdays(DateTime inputDate)
    {
        DateTime today = new DateTime();
        today = DateTime.Today;
        DateTime [] hollidays = 
        { 
            new DateTime(2013,5,1),   
            new DateTime(2013,5,2),
            new DateTime(2013,5,3),
            new DateTime(2013,5,6),
            new DateTime(2013,5,24),
            new DateTime(2013,9,6),
            new DateTime(2013,12,24),
            new DateTime(2013,12,25),
            new DateTime(2013,12,26)
        };
        
        bool isWorkday = true;
        int countWorkdays = 0;
        today = today.AddDays(1);
        while (today.Equals(inputDate) == false)
        {
            string day = today.DayOfWeek.ToString();
            if (day.CompareTo("Sunday") == 0 || day.CompareTo("Saturday") == 0)
            {
                isWorkday = false;
            }

            if (isWorkday)
            {
                foreach (var date in hollidays)
                {
                    if (today.Equals(date))
                    {
                        isWorkday = false;
                        break;
                    }
                }
            }

            if (isWorkday)
            {
                countWorkdays++;
            }

            else
            {
                isWorkday = true;
            }

            today = today.AddDays(1);
        }

        return countWorkdays;
    }

    static void Main()
    {
        DateTime inputDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("The number of workdays is: {0}", Workdays(inputDate));
    }
}

