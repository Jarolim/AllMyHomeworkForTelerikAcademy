using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentQueries
{
    class QueriesHandler
    {
        public static ICollection<Student> GetStudentsWithFirstNameBeforeLastName(ICollection<Student> students)
        {
            ICollection<Student> group = new List<Student>();

            var queryReturnedObject =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            foreach (var item in queryReturnedObject)
            {
                group.Add(item);
            }

            return group;
        }

        public static ICollection<Student> GetStudentsWithAgeInRange(ICollection<Student> students, int rangeFrom, int rangeTo)
        {
            if (rangeFrom > rangeTo)
            {
                throw new ArgumentException("From in range cannot be larger than To.");
            }
            ICollection<Student> group = new List<Student>();

            var queryReturnedObject = 
                from student in students
                where student.Age >= rangeFrom && student.Age <= rangeTo
                select student;

            foreach (var item in queryReturnedObject)
            {
                group.Add(item);
            }

            return group;
        }

        public static void SortByLambdaExpression(ref ICollection<Student> students)
        {
            ICollection<Student> sortedCollection = new List<Student>();

            var sortedObject = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            
            foreach (var item in sortedObject)
            {
                sortedCollection.Add(item);
            }

            students = sortedCollection;
        }

        public static void SortByLINQ(ref ICollection<Student> students)
        {
            ICollection<Student> sortedCollection = new List<Student>();

            var sortedObject =
                from student in students
                orderby student.FirstName, student.LastName descending
                select student;

            foreach (var item in sortedObject)
            {
                sortedCollection.Add(item);
            }

            students = sortedCollection;
        }

        public static void Sort(ref ICollection<Student> students)
        {
            //SortByLambdaExpression(ref students);
            SortByLINQ(ref students);
        }

        static void Main(string[] args)
        {
            ICollection<Student> students = new List<Student>();

            students.Add(new Student("Anton", "Stoilov", 19));
            students.Add(new Student("Georgi", "Bakardjiev", 39));
            students.Add(new Student("Simeon", "Manolov", 23));
            students.Add(new Student("Georgi", "Kehaiov", 18));

            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            // Exercise 3

            ICollection<Student> nameGroup = GetStudentsWithFirstNameBeforeLastName(students);

            foreach (Student student in nameGroup)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            // Exercise 4

            ICollection<Student> ageGroup = GetStudentsWithAgeInRange(students, 18, 24);

            foreach (Student student in ageGroup)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            // Exercise 5

            Sort(ref students);

            Console.WriteLine("Sorted list:");
            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
            
        }
    }
}
