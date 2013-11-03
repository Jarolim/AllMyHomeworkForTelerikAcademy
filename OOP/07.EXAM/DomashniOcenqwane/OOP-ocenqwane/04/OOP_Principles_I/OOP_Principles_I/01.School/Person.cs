using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    public class Person:Disciplines,Icommentable
    {
        public Person() { }
        public Person(string name)
        {
            this.name = name;
        }
    }
}
