using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV._2.OOP.Homework
{
    class Student: Human
    {
        private float grade;

        public Student(string firstName, string lastName, float grade): base(firstName, lastName)
        {
            this.grade = grade;
        }

        public float Grade
        {
            get {return this.grade;}
            private set
            {
                if (grade >= 2 && grade <= 6)
                {
                    { this.grade = value; }
                }
                else
                {
                    throw new ArgumentException("Invalid grade. Must be between 2 and 6!");
                }
            }
        }

    }
}
