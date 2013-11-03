using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsGroup
{
    class Kitten : Cat, ISound
    {
        public Kitten(string pName, Sexes pSex, int pAge)
            : base(pName, pSex, pAge) 
        {
            if (pSex == Sexes.male)
                throw new ArgumentOutOfRangeException("Kittens can be only female!");
        }

        public override string ProduceSound()
        {
            return "Myau!";
        }
    }
}
