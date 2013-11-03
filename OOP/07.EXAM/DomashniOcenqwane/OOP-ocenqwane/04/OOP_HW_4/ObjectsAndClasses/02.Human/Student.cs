using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanGroup
{
    class Student : Human
    {
        public float Grade { get; private set; }

        public Student (string pFirstName, string pLastName) 
            : base (pFirstName, pLastName){}

        public Student(string pFirstName, string pLastName, float pGrade)
            : this(pFirstName, pLastName) 
        {
            if ((pGrade < 2) || (pGrade > 6))
                throw new ArgumentOutOfRangeException("Invalid student grade!");
            this.Grade = pGrade;
        }
    }
}
