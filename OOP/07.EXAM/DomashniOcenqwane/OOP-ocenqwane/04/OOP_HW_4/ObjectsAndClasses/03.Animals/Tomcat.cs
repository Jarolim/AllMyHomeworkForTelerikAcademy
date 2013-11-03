using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalsGroup
{
    class Tomcat : Cat, ISound
    {
        public Tomcat (string pName, Sexes pSex, int pAge)
            : base(pName, pSex, pAge) 
        {
            if (pSex == Sexes.female)
                throw new ArgumentOutOfRangeException("Tomcats can be only male!");
        }

        public override string ProduceSound()
        {
            return "Miauuu!";
        }
    }
}
