using System;

namespace School
{
    class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Person (string pFirstName, string pLastName)
        {
            this.FirstName = pFirstName;
            this.LastName = pLastName;
        }
    }
}
