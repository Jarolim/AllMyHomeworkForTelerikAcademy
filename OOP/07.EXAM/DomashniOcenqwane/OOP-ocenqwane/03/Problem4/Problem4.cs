using System;
using System.Linq;

namespace Problem4
{
	class Problem4
	{
		static void Main()
		{
			var students = new[] {new { FirstName = "George", LastName = "Ivanov", Age = 18 },
							   new { FirstName = "Ivan", LastName = "Georgiev", Age = 25 },
							   new { FirstName = "Stefan", LastName = "Stefanov", Age = 22 } };

			var selected =	from student in students
						where student.Age >= 18 && student.Age <= 24
						select (student.FirstName + " " + student.LastName + " " + student.Age);

			foreach (var item in selected)
				Console.WriteLine(item);

		}
	}
}
