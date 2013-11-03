using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Frog:Animal,ISound
    {
        public Frog(int age, string name, string sex) : base(age, name, sex) 
        { 
        }

        public override void MakeSound()
        {
            Console.WriteLine("Kwak! kwak!");
        }
    }
}
