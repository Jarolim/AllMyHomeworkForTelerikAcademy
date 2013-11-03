using System;
using System.Linq;

namespace Problem5LINQ
{
	class Problem5LINQ
	{
		static void Main(string[] args)
		{
			var students = new[] {new { FirstName = "George", LastName = "Ivanov", Age = 18 },
						new { FirstName = "Ivan", LastName = "Georgiev", Age = 25 },
						new { FirstName = "Stefan", LastName = "Stefanov", Age = 22 } };

			var selected =	from student in students
						orderby student.FirstName descending, student.LastName descending
						select (student.FirstName + " " + student.LastName + " " + student.Age);

			foreach (var item in selected)
				Console.WriteLine(item);

		}
	}
}
