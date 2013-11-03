using System;
using System.Linq;


namespace Bank.Common
{
    public class CompanyCustomer : Customer
    {
        public CompanyCustomer(string companyName, string phoneNumber) : base(companyName, string.Empty, string.Empty, phoneNumber)
        {
        }

        public override string ToString()
        {
            return string.Format("Company Name: {0}, Number: {1}",this.FirstName, this.PhoneNumber);
        }
    }
}