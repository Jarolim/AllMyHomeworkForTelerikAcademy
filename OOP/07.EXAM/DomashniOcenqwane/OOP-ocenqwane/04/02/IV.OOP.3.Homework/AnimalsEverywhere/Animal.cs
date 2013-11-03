using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    public class Animal
    {
        private int age;
        private EnumSex sex;
        private string name;
   
        public Animal(string name, int age)
            : this(name, age, EnumSex.male)
        {

        }

        public Animal(string name, int age, EnumSex sex)
        {
            this.Name = name;
            this.Age = age;
            this.sex = sex;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value != string.Empty && value.Length >= 2)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value >= 0 && value <= 18)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("The age must be between 0 and 18!");
                }
            }
        }

        public EnumSex Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public static IEnumerable<Tuple<string, double>> AverageAge(Animal[] animals)
        {
            var averageAges =
                from critter in animals
                group critter by critter.GetType() into animalType
                select new Tuple<string, double>(animalType.Key.Name, animalType.Average(a => a.Age));

            return averageAges;
        }
    }
}
