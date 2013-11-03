using System;
using System.Linq;

namespace Bank.Common
{
    public class IndividualCustomer:Customer
    {
        public IndividualCustomer(string firstName, string secondName, string lastName, string phoneNumber) : base(firstName, secondName, lastName, phoneNumber)
        {
        }
        
    }
}
