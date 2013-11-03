/*
 * Task 1: Write a program that reads a year from the console 
 * and checks whether it is a leap. Use DateTime.
 */

using System;

namespace LeapYear
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("Year: ");
			int year = int.Parse(Console.ReadLine());

			bool isLead = DateTime.IsLeapYear(year);
			string resultText = isLead ? "The year is leap." : "The year is not leap.";
			Console.WriteLine(resultText);
		}
	}
}