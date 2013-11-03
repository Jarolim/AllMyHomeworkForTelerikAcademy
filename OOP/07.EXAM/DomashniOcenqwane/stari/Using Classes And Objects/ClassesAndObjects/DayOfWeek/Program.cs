/*
 * Task 3: Write a program that prints to the console which day 
 * of the week is today. Use System.DateTime.
 */

using System;

namespace DayOfWeek
{
	internal class Program
	{
		private static void Main()
		{
			PrintCurrentDayOfWeek();
		}

		private static void PrintCurrentDayOfWeek()
		{
			Console.WriteLine("Today is {0}.", DateTime.Now.DayOfWeek);
		}
	}
}