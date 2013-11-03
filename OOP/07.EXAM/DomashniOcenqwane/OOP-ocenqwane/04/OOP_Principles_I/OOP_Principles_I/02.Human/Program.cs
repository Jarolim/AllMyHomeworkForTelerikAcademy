using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>(12);
            students.Add(new Student("Ivan", "Petrov", 3));
            students.Add(new Student("Ivailo", "Draganov", 3));
            students.Add(new Student("Rosen", "Plevneliev", 2));
            students.Add(new Student("Boiko", "Borisov", 4));
            students.Add(new Student("Dimitur", "Berbatov", 3));
            students.Add(new Student("Iva", "Stoilova", 2));
            students.Add(new Student("Iva", "Kostadinova", 3));
            students.Add(new Student("Emil", "Dimitrov", 1));
            students.Add(new Student("Rumen", "Ovcharov", 3));
            students.Add(new Student("Slavi", "Binev", 1));

            var studentsSortedByGrade = from Student in students
                         orderby Student.grade
                         select Student;
            
            //foreach (var student in sorted)
            //{
            //    Console.WriteLine(student);
            //}

            List<Worker> workers = new List<Worker>() { };
            workers.Add(new Worker("Ebasi", "Rabotnika", 300, 6));
            workers.Add(new Worker("Obi", "Rjiqta", 899, 6));
            workers.Add(new Worker("Komar", "Jiqta", 500, 2));
            workers.Add(new Worker("Hans", "Piko", 123, 1));
            workers.Add(new Worker("Coco", "Rabotnika", 344, 6));
            workers.Add(new Worker("Mitko", "Pavlov", 600, 10));
            workers.Add(new Worker("Cari", "Hasan", 300, 6));
            workers.Add(new Worker("Bobo", "Petkov", 1333, 15));
            workers.Add(new Worker("Momo", "Dobrev", 299, 1));
            workers.Add(new Worker("Koko", "Shefa", 1200, 6));

            var workerSortedByMph = from Worker in workers
                      orderby Worker.MoneyPerHour
                      select Worker;


            List<Human> _students = new List<Human>(studentsSortedByGrade);
            List<Human> _workers = new List<Human>(workerSortedByMph);

            _students = _students.Concat(_workers).ToList();

            var mergedStudentsAndWorkers = from Human in _students
                         orderby Human.firstName.Length, Human.secondName.Length
                         select Human;

            foreach (var item in mergedStudentsAndWorkers)
            {
                Console.WriteLine("{0}\n",item);
            }
                
        }

        
    }
}
