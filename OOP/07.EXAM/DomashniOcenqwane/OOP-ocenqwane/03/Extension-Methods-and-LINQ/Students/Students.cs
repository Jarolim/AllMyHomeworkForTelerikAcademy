using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student
    {
        public string FirstName{ get; set; }
        public string LasttName{ get; set; }
        public int Age { get; set; }
// Constructor
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LasttName = lastName;
            this.Age = age;
        }
    }
}
