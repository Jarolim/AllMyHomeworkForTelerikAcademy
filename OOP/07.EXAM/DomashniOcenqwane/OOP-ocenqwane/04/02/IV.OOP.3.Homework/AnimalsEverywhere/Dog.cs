using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    public class Dog : Animal, ISpeach
    {
        public Dog(string name, int age)
            : base(name, age)
        {

        }

        public Dog(string name, int age, EnumSex sex)
            : base(name, age, sex)
        {

        }

        public string AnimalSound()
        {
            return "Bau!";
        }
    }
}
