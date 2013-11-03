using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsGroup
{
    class Dog : Animal, ISound
    {
        public Dog(string pName, Sexes pSex, int pAge)
            : base(pName, pSex, pAge) { }

        public override string ProduceSound()
        {
            return "Bau!";
        }
    }
}
