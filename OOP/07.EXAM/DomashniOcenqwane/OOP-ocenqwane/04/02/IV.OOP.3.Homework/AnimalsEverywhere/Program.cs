using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    class Program
    {
        static void Main()
        {
            Dog dog = new Dog("Grubi", 1);

            Frog frog = new Frog("Princess Diana", 3);

            Tomcat tomcat = new Tomcat("Tyson", 5);

            Console.WriteLine("{0} say: {1}", tomcat.Name, tomcat.AnimalSound());

            Console.WriteLine("{0} say: {1}", dog.Name, dog.AnimalSound());

            Console.WriteLine("{0} say: {1}", frog.Name, frog.AnimalSound());

            Console.WriteLine();

            Animal[] animals = 
        {
                new Dog("Sharo", 12),
                new Dog("Gosho", 1), 
                new Dog("Eiti", 7),
                new Kitty("Maco", 0),
                new Kitty("Frodo", 1),
                new Frog("Kvazimodo", 3),
                new Frog("Kiss me", 5),
                new Tomcat("Tommy", 5),
                new Tomcat("Gribo", 12)
        };

            var averageAges = Animal.AverageAge(animals);

            foreach (var typeAnimal in averageAges)
            {
                Console.WriteLine("Animal: {0} with average age: {1:F2}.", typeAnimal.Item1, typeAnimal.Item2);
            }
            Console.WriteLine();
        }
    }
}
