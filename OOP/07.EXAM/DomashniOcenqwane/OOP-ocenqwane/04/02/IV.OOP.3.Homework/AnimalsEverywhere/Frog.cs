using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    public class Frog : Animal, ISpeach
    {
        public Frog(string name, int age)
            : base(name, age)
        {

        }

        public Frog(string name, int age, EnumSex sex)
            : base(name, age, sex)
        {

        }

        public string AnimalSound()
        {
            return "Kvak!";
        }
    }
}
