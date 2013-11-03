using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
    class Person
    {
        public string name;
        public Nullable<int> age;

        public Person(string name, Nullable<int> age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            string result = this.name;
            if (age != null)
                result += this.age;
            else result += "No age specified";

            return result;
        }
    }
}
