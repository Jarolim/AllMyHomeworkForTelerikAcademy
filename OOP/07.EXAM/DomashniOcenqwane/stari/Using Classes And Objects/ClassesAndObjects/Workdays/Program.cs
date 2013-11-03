/*
 * Task 5: Write a method that calculates the number of workdays
 * between today and given date, passed as parameter. Consider
 * that workdays are all days from Monday to Friday except a 
 * fixed list of public holidays specified preliminary as array.
 */

using System;

namespace Workdays
{
	internal class Program
	{
		private static readonly DateTime[] Holidays;

		//Constructor
		static Program()
		{
			int currentYear = DateTime.Now.Year;
			Holidays = new[]
			           	{
			           		new DateTime(currentYear, 1, 1),
			           		new DateTime(currentYear, 3, 3),
			           		new DateTime(currentYear, 5, 1),
			           		new DateTime(currentYear, 5, 2),
			           		new DateTime(currentYear, 5, 6),
			           		new DateTime(currentYear, 5, 24),
			           		new DateTime(currentYear, 9, 22),
			           		new DateTime(currentYear, 12, 24),
			           		new DateTime(currentYear, 12, 25),
			           		new DateTime(currentYear, 12, 26),
			           		new DateTime(currentYear, 12, 31),
			           	};
		}

		private static void Main()
		{
			Console.WriteLine("CHECK WORK DAYS");
			Console.WriteLine("for the period from today to:");

			Console.Write("Year: ");
			short year = short.Parse(Console.ReadLine());

			Console.Write("Month: ");
			byte month = byte.Parse(Console.ReadLine());

			Console.Write("Day: ");
			byte day = byte.Parse(Console.ReadLine());

			var nextDate = new DateTime(year, month, day);
			int workDays = GetWorkDays(nextDate);

			Console.WriteLine("Between today and {0} there are {1} work days.", nextDate.ToShortDateString(), workDays);
		}

		private static int GetWorkDays(DateTime endDate)
		{
			if (endDate <= DateTime.Today)
			{
				return 0;
			}

			int workDays = 0;
			DateTime currentDate = DateTime.Today;
			while (endDate.Date - currentDate.Date > TimeSpan.Zero)
			{
				bool isWorkDay = currentDate.DayOfWeek != DayOfWeek.Sunday
				                 && currentDate.DayOfWeek != DayOfWeek.Saturday;

				bool isHoliday = IsHoliday(currentDate);

				if (isWorkDay && !isHoliday)
				{
					workDays++;
				}

				currentDate = currentDate.AddDays(1);
			}

			return workDays;
		}

		private static bool IsHoliday(DateTime currentDate)
		{
			foreach (DateTime holiday in Holidays)
			{
				if (holiday.Date == currentDate)
				{
					return true;
				}
			}

			return false;
		}
	}
}