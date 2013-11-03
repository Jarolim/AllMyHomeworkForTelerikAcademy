using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Kitten:Cat,ISound
    {
        public Kitten(int age, string name, string sex) : base(age, name, "female") 
        {
            if (sex != "female")
            {
                sex = "female";
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("mieee mieee");
        }
    }
}
