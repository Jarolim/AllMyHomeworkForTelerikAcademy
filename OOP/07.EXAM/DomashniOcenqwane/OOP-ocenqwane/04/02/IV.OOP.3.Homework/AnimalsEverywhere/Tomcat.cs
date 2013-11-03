using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEverywhere
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, EnumSex.male)
        {
        }

        public EnumSex Sex
        {
            get { return base.Sex; }
            private set { }
        }

        public string AnimalSound()
        {
            return "Miauu! (Feed me!)";
        }
    }
}
