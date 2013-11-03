using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class TestAnimals
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>() {};
            animals.Add(new Dog(6, "sharo", "male"));
            animals.Add(new Cat(7, "mariika", "female"));
            animals.Add(new Frog(2, "frogert", "male"));
            animals.Add(new Kitten(2, "lily", "female"));
            animals.Add(new Tomcat(13, "Tom", "male"));
            animals.Add(new Dog(13, "Rosen", "female"));
            animals.Add(new Cat(15, "Minka", "female"));
            animals.Add(new Frog(7, "Roberto", "male"));
            animals.Add(new Kitten(3, "kitty", "female"));
            animals.Add(new Tomcat(9, "Ernesto", "male"));
            animals.Add(new Cat(11, "Choko", "male"));
            animals.Add(new Cat(8, "Bobi", "female"));
            animals.Add(new Dog(6, "Rumen", "male"));
            animals.Add(new Cat(13, "Qna", "female"));
            animals.Add(new Frog(4, "Daiana", "female"));
            animals.Add(new Kitten(1, "katty", "female"));
            
            foreach (var item in animals)
            {
                Console.Write(item);
                item.MakeSound();
                
            }

            Animal.GetAverageAge(animals);
        }
    }
}
