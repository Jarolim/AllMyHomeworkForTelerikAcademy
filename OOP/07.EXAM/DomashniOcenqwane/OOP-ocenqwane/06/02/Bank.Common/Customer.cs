using System;
using System.Linq;

namespace Bank.Common
{
    public abstract class Customer
    {
        private string firstName;
        private string secondName;
        private string lastName;
        private string phoneNumber;

        public Customer(string firstName, string secondName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Customer:{0} {1} {2},PhoneNumber:{3}", FirstName, SecondName, LastName, PhoneNumber);
        }
    }
}