using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV._2.OOP.Homework
{
    class Program
    {
        static void Main()
        {
            Student student1 = new Student("Bai", "Spiro", 5);
            Student student2 = new Student("Kiro", "Mastikata", 5);
            Student student3 = new Student("Dimitar", "Penev", 4);
            Student student4 = new Student("Milcho", "Georgiev", 4.2f);
            Student student5 = new Student("Gospodin", "Slagachev", 6);
            Student student6 = new Student("Krali", "Marko", 3.2f);
            Student student7 = new Student("Cherno", "Feredje", 3);
            Student student8 = new Student("Karl", "Veliki", 5.65f);
            Student student9 = new Student("Ivan", "Grozni", 6);
            Student student10 = new Student("Zaio", "Baio", 2);


            Worker worker1 = new Worker("Kalinka", "Malinka", 400.80m, 8);
            Worker worker2 = new Worker("Malkata", "Drusalka", 66.66m, 13);
            Worker worker3 = new Worker("Gospoja", "Ignatieva", 300.66m, 8);
            Worker worker4 = new Worker("Princesa", "Jozefina", 999.99m, 10);
            Worker worker5 = new Worker("Snejanka", "Kovacheva", 1110.00m, 6);
            Worker worker6 = new Worker("Chervenata", "Shapka", 1000.61m, 8);
            Worker worker7 = new Worker("Stanka", "Magistralska", 1183.70m, 9);
            Worker worker8 = new Worker("Ginka", "Panajotova", 590.60m, 8);
            Worker worker9 = new Worker("Iordanka", "Dimitrova", 900.43m, 14);
            Worker worker10 = new Worker("Bash", "Pimpa", 3503.60m, 3);

            List<Student> students = new List<Student>{student1, student2, student3, student4, student5,
                student6, student7, student8, student9, student10};

            var sortedStudents = from student in students orderby student.Grade select student;

            Console.WriteLine("The list of sorted students by their grades: ");

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " - " + student.Grade);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>{worker1, worker2, worker3, worker4, worker5,
                worker6, worker7, worker8, worker9, worker10};

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            Console.WriteLine("The list of sorted workers by their money per hour: ");

            foreach (Worker worker in sortedWorkers)
            {
                Console.WriteLine(worker.FirstName + " " + worker.LastName + " - " + worker.MoneyPerHour().ToString ("#.##"));
            }

            Console.WriteLine();

            List<dynamic> mergedList = new List<dynamic>(students.Union<dynamic>(workers));

            Console.WriteLine("The list of sorted students and workers by their first and last name: ");

            var sortedPersons = from people in mergedList orderby people.FirstName, people.LastName select people;

            foreach (var person in sortedPersons)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }
    }
}
