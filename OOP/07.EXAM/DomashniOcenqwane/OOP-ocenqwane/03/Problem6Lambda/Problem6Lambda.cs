using System;
using System.Linq;

namespace Problem6Lambda
{
	class Problem6Lambda
	{
		static void Main()
		{
			int[] numbers = new int[] { 1, 3, 7, 21, 42, 55 };

			var selected = numbers.Where(number => number % 21 == 0);

			foreach (var item in selected)
				Console.WriteLine(item);

		}
	}
}
