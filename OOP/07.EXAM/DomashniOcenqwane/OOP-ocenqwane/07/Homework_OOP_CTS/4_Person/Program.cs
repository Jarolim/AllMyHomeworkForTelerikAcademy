using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Person
{
    class Program
    {
        static void Main()
        {
            Person[] persons = 
        {
            new Person("Pesho", 45),
            new Person("Tosho"),
            new Person("Sasho", 16 ),
            new Person("Asia"),
        };

            foreach (var person in persons)
            {
                Console.WriteLine("Person Information:");
                Console.WriteLine("------------------");
                Console.WriteLine(person);
            }
        }
    }
}
