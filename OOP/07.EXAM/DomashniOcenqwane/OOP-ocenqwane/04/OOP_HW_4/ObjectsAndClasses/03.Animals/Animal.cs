using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsGroup
{
    abstract class Animal : ISound
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public Sexes Sex { get; private set; }

        public Animal (string pName, Sexes pSex, int pAge)
        {
            this.Name = pName;
            this.Sex = pSex;
            this.Age = pAge;
        }

        public static float CalculateAge(Animal[] animalArr)
        {
            return (float)animalArr.Average(x => x.Age);
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return String.Format("{0} {1} - {2} ({3})", this.GetType().ToString(), this.Sex, this.Name, this.Age);
        }
    }
}
