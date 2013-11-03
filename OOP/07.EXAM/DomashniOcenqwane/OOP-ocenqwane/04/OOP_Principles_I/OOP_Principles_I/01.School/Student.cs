using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
     public class Student : Person,Icommentable
    {
        //field 
        private int studentNumber;

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }
            set
            {
                this.studentNumber = value;
            }
        }

        //constructor
        public Student(string name, int studentNumber)
            :base(name)
        {
            this.name = name;
            this.studentNumber = studentNumber;
        }
         //to string
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("name: {0} - number : {1}",
                this.name.ToString(),this.studentNumber.ToString());
                
            return output.ToString();
        }


 
    
    }
    
}
