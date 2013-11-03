using System;
using System.Linq;

namespace Problem6LINQ
{
	class Problem6LINQ
	{
		static void Main()
		{
			int[] numbers = new int[] { 1, 3, 7, 21, 42, 55 };

			var selected =	from number in numbers
						where number % 21 == 0
						select number;

			foreach (var item in selected)
				Console.WriteLine(item);

		}
	}
}
