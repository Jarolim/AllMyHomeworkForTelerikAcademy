using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    class Program
    {
        static void Main()
        {

            #region CREATE TEST OBJ
            //discipline
            List<Disciplines> disciplines = new List<Disciplines>();
            disciplines.Add(new Disciplines("Chemistry", 4, 6));
            disciplines.Add(new Disciplines("Math", 10, 10));
            disciplines.Add (new Disciplines("Biology", 8, 6));
            disciplines.Add(new Disciplines("Insurance", 10, 6));
            disciplines.Add(new Disciplines("Informatics", 10, 16));

            //teachers

            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(new Teacher("Manolov",disciplines.GetRange(3,1)));
            teachers.Add(new Teacher("Minkov",disciplines.GetRange(0,2)));
            teachers.Add(new Teacher("Marinov", disciplines.GetRange(2, 1)));
            teachers.Add(new Teacher("Ovcharov", disciplines.GetRange(0, 3)));
            
                         
            //students
            List<Student> students = new List<Student>();
            students.Add(new Student("Martin", 3));
            students.Add(new Student("Darin", 13));
            students.Add(new Student("Rumqna", 6));
            students.Add(new Student("Emil", 33));
            students.Add(new Student("Nikola", 7));
            students.Add(new Student("Georgi", 1));
            
            //SchoolClasses
            List<SchoolClass> schoolClasses = new List<SchoolClass>();
            schoolClasses.Add(new SchoolClass(teachers, students, "3133"));            
           
            //school
            School school = new School("School Akademy",schoolClasses);   
            #endregion

            //-----TEST SCHOOL-------
            Console.WriteLine(school);

            #region TEST OPTIONAL COMMENTS
            Student vasko = new Student("Vasko",3);
            vasko.FreeComments = "OPTIONAL COMMENT TEST";
            vasko.ShowFreeComments();

            Teacher ra = new Teacher("Vasko", disciplines);
            ra.FreeComments = "OPTIONAL COMMENT TEST";
            ra.ShowFreeComments();

            SchoolClass da = new SchoolClass(teachers,students,"31231");
            da.FreeComments = "OPTIONAL COMMENT TEST";
            da.ShowFreeComments();
            #endregion

        }
        
    }
}
