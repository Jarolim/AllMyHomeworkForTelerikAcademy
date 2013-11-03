/*
 * Task 6: You are given a sequence of positive integer values written
 * into a string, separated by spaces. Write a function that reads these
 * values from given string and calculates their sum.
 */

using System;

namespace SumStringNumbers
{
	internal class Program
	{
		private static void Main()
		{
			const string spacesString = "43 68 9 23 318 21and some words";
			Console.WriteLine(GetSpacesStringNumbersSum(spacesString));
		}

		private static int GetSpacesStringNumbersSum(string spacesString)
		{
			//Adds blank space to the end, because every number should have an interval after it
			spacesString = spacesString.Trim();
			spacesString += " ";

			//Get numbers count
			int spacesCount = 0;
			for (int i = 0; i < spacesString.Length; i++)
			{
				if (spacesString[i] == ' ')
				{
					spacesCount++;
				}
			}

			//Get numbers
			var numbers = new string[spacesCount];
			int currentNumber = 0;
			for (int i = 0; i < spacesString.Length; i++)
			{
				if (spacesString[i] == ' ')
				{
					currentNumber++;
				}
				else
				{
					numbers[currentNumber] += spacesString[i];
				}
			}

			//Get sum
			int sum = 0;
			foreach (string number in numbers)
			{
				bool isNumber = IsNumber(number);
				if (isNumber)
				{
					sum += int.Parse(number);
				}
			}

			return sum;
		}

		private static bool IsNumber(string number)
		{
			foreach (char digit in number)
			{
				if (!char.IsDigit(digit))
				{
					return false;
				}
			}

			return true;
		}
	}
}