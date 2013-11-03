/*
 * Task 2: Write a program that generates and prints to the console 
 * 10 random values in the range [100, 200].
 */

using System;

namespace TenRandomValues
{
	internal class Program
	{
		private static readonly Random Rand = new Random();

		private static void Main()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(Rand.Next(100, 201));
			}
		}
	}
}