using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Tomcat:Cat,ISound
    {
        public Tomcat(int age, string name, string sex) : base(age, name, "male") 
        {
            if (sex != "male")
            {
                sex = "male";
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("MEOW!!!!");
        }
    }
}
