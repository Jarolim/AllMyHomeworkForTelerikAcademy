using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Student:Human
    {
        public int grade { get; set; }

        public Student(string firstName , string secondName,int grade):base(firstName,secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.grade = grade;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} grade: {1} ",base.ToString(),
                this.grade.ToString());

            return output.ToString();
        }

    }
}
