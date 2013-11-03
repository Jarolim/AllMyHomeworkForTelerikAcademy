using System;
using System.Linq;

namespace Problem3
{
	class Problem3
	{
		static void Main()
		{
			var students = new[] {new { FirstName = "George", LastName = "Ivanov" },
							   new { FirstName = "Ivan", LastName = "Georgiev" },
							   new { FirstName = "Stefan", LastName = "Stefanov" } };

			var selected =	from student in students
						where student.FirstName.CompareTo(student.LastName) == -1
						select (student.FirstName + " " + student.LastName);

			foreach (var item in selected)
				Console.WriteLine(item);
		}
	}
}
