using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV._2.OOP.Homework
{
    public abstract class Human
    {
        private readonly string firstName;
        private readonly string lastName;

        protected internal Human(string firstName, string lastName)
        {
            if (firstName != string.Empty && firstName.Length >= 2)
            {
                this.firstName = firstName;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid First name!");
            }

            if (lastName != string.Empty && lastName.Length >= 2)
            {
                this.lastName = lastName;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid Last name!");
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }
    }
}
