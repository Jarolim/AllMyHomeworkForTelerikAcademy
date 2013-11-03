using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Teacher:Person
    {
        public List<Disciplines> disciplines { get; private set; }       
        
        public Teacher(string name, List<Disciplines> disciplines)
            :base(name)
        {
            this.disciplines = disciplines;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Teacher name: {0}\n",this.name);
            foreach (var item in disciplines)
            {
                output.AppendLine(item.ToString());               
            }                        
            return output.ToString();
        }
    }
}
