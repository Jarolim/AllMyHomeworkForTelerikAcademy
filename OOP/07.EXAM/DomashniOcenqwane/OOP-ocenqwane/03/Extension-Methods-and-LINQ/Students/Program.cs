using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static Student[] FirstBeforeLast(Student[] inArray)
        {
           var selected =
                from student in inArray
                where student.FirstName.CompareTo(student.LasttName) < 0
                select student;
           return selected.ToArray();

        }
        static string[] AgeBetween18and24(Student[] inArray)
        {
            var selected =
             from student in inArray
             where (student.Age > 18 && student.Age < 24)
             select (student.FirstName + " " + student.LasttName);
            return selected.ToArray();
        }
        static Student[] OrderedByNamesLambda(Student[] inArray)
        {
            var ordered = inArray.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LasttName);
            return ordered.ToArray();

        }
        static Student[] OrderedByNames(Student[] inArray)
        {
            var ordered =
                 from student in inArray
                 orderby student.FirstName descending, student.LasttName descending
                 select student;
            return ordered.ToArray();

        }
        static void Main(string[] args)
        {
            Student[] studentsArray = new Student[5]
            {
                new Student("Kristian","Bojadjiev",25),
                new Student("Antoniq","Petrova",19),
                new Student("Viktor","Kynchelov",23),
                new Student("Viktor","Zashev",31),
                new Student("Psiho","Sum",15)
            };
            Console.WriteLine("----Selected First before Last----");
            Student[] selected = FirstBeforeLast(studentsArray);
            foreach (var item in selected)
            {
                Console.WriteLine(item.FirstName+" "+ item.LasttName);
            }
            Console.WriteLine("----Selected Age between 18 and 24----");
            string[] selectedAge = AgeBetween18and24(studentsArray);
            foreach (var item in selectedAge)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----Ordered by names Lambda----");
            Student[] orderedLambda = OrderedByNamesLambda(studentsArray);
            foreach (var item in orderedLambda)
            {
                Console.WriteLine(item.FirstName + " " + item.LasttName);
            }
            Console.WriteLine("----Ordered by names LINQ----");
            Student[] orderedLINQ = OrderedByNames(studentsArray);
            foreach (var item in orderedLINQ)
            {
                Console.WriteLine(item.FirstName + " " + item.LasttName);
            }
        }
    }
}
