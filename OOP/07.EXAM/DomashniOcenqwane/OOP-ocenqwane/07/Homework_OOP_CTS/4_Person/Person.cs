using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Person
{
    class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person(string name)
            : this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            if (name == null || name == string.Empty)
            {
                throw new Exception("Name must be specified!");
            }
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder person = new StringBuilder();
            person.AppendFormat("Person Name: {0}", this.Name).AppendLine();
            person.AppendFormat(this.Age == null ? "The person has no age!" : "Person Age:" + this.Age).AppendLine();
            return person.ToString();
        }
    }
}
