using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanGroup
{
    abstract class Human
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Human(string pFirstName, string pLastName)
        {
            this.FirstName = pFirstName;
            this.LastName = pLastName;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
