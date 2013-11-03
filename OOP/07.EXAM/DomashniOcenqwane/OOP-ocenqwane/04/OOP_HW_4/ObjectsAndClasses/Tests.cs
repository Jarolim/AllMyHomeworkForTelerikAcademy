//Task02
//Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method). 
//Initialize a list of 10 workers and sort them by money per hour in descending order. 
//Merge the lists and sort them by first name and last name.

//Task03
//Create arrays of different kinds of animals and calculate the average age of each kind of animal 
//using a static method (you may use LINQ).


using System;
using System.Collections.Generic;
using System.Linq;
using StudentLink = HumanGroup.Student;
using WorkerLink = HumanGroup.Worker;
using HumanLink = HumanGroup.Human;
using AnimalsGroup;

namespace School
{
    class Tests
    {
        static void Main(string[] args)
        {
            //------
            //Task02
            //------

            List<StudentLink> studentList = new List<StudentLink>() { 
                new StudentLink("Petar", "Ivanov", 2.57f),
                new StudentLink("Ivan", "Petrov", 3.17f),
                new StudentLink("Kaloqn", "Stanev", 6.00f),
                new StudentLink("Stanislav", "Todorov", 4.71f),
                new StudentLink("Todor", "Dimitrov", 2.00f),
                new StudentLink("Dimitar", "Todorov", 3.33f),
                new StudentLink("Pavel", "Simeonov", 4.57f),
                new StudentLink("Simeon", "Pavlov", 4.58f),
                new StudentLink("Stanimir", "Stoqnov", 4.59f),
                new StudentLink("Stoqn", "Stanimirov", 5.69f),
            };

            studentList = studentList.OrderBy(x => x.Grade).ToList();

            Console.WriteLine(new String ('*', 20));
            Console.WriteLine("Students sorted grade:");
            foreach (StudentLink student in studentList)
            {
                Console.WriteLine(student);
            }

            List<WorkerLink> workerList = new List<WorkerLink>() { 
                new WorkerLink("Stefan", "Karaivanov", 500, 9),
                new WorkerLink("Kiro", "Stefanov", 510, 8),
                new WorkerLink("Milan", "Kirov", 450, 11),
                new WorkerLink("Deqn", "Milanov", 780, 8),
                new WorkerLink("Zahary", "Dimitrov", 810, 8),
                new WorkerLink("Zahary", "Deqnov", 330, 10),
                new WorkerLink("Dimitar", "Kirov", 400, 9),
                new WorkerLink("Simeon", "Dimitrov", 470, 8),
                new WorkerLink("Stanimir", "Karaivanov", 550, 10),
                new WorkerLink("Stoqn", "Tanev", 1000, 6),
            };

            workerList = workerList.OrderByDescending(x => x.MoneyPerHour()).ToList();

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Workers sorted by money per hour:");
            foreach (WorkerLink worker in workerList)
            {
                Console.WriteLine(worker);
            }

            List<HumanLink> studentsAndWorkers = new List<HumanLink>();

            studentsAndWorkers.AddRange(studentList);
            studentsAndWorkers.AddRange(workerList);

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Workers and students together:");
            foreach (HumanLink human in studentsAndWorkers)
            {
                Console.WriteLine(human);
            }


            //------
            //Task03
            //------

            Animal[] animalArr = new Animal[] {
                new Cat("Madam", Sexes.female, 5),
                new Kitten("Purr", Sexes.female, 3),
                new Tomcat("Rage", Sexes.male, 4),
                new Dog("Milo", Sexes.male, 7),
                new Frog("Prince", Sexes.female, 2)
            };

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("The animals are:");
            foreach (Animal animal in animalArr)
            {
                Console.WriteLine("{0} - {1}", animal, animal.ProduceSound());
            }

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("The average age of the animals is:");
            Console.WriteLine(Animal.CalculateAge(animalArr));
        }
    }
}
