using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main()
        {
            Student stdFirst = new Student("Snejko", 12);
            Student stdSecond = new Student("Bai Spiro", 1);
            Student stdThird = new Student("Kashchei Bezsmurtni", 99);
            Discipline disciplFirst = new Discipline("Combene na jenki", 1, 1);
            Discipline disciplSecond = new Discipline("Grebane s lujica", 10, 10);
            Discipline disciplThird = new Discipline("Sky Diving", 10, 0);
            List<Discipline> bobTheTurboObjects = new List<Discipline>();
            bobTheTurboObjects.Add(disciplFirst);
            bobTheTurboObjects.Add(disciplSecond);
            bobTheTurboObjects.Add(disciplThird);
            Teacher teacherFirst = new Teacher("Bobi Turboto", bobTheTurboObjects);

            Console.WriteLine("The only one teacher in the school is: " + teacherFirst.TeacherName + ". Imagine what kind of school is that !");

            Console.WriteLine("Bobi Turboto lectures students on these disciplines: ");
            foreach (Discipline discipline in teacherFirst.TeacherObjects)
            {
                Console.WriteLine();
                Console.WriteLine(discipline.ObjectName);
            }

        }
    }
}
