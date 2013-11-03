using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    public class Kitty : Cat
    {
        public Kitty(string name, int age)
            : base(name, age, EnumSex.female)
        {
        }

        // in this way I make this property to be always female
        public EnumSex Sex
        {
            get { return base.Sex; }
            private set { }
        }

        public string AnimalSound()
        {
            return "MIAUUUUUU!";
        }
    }
}
