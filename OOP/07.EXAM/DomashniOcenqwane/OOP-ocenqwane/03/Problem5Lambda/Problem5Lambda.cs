using System;
using System.Linq;

namespace Problem5Lambda
{
	class Problem5Lambda
	{
		static void Main()
		{
			var students = new[] {new { FirstName = "George", LastName = "Ivanov", Age = 18 },
						new { FirstName = "Ivan", LastName = "Georgiev", Age = 25 },
						new { FirstName = "Stefan", LastName = "Stefanov", Age = 22 } };

			var selected = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

			foreach (var item in selected)
				Console.WriteLine(item);


		}
	}
}
