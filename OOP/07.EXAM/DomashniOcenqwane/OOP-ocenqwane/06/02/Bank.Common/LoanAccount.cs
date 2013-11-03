using System;
using System.Linq;


namespace Bank.Common
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("The amount can not be less then zero");
            }
            this.Balance += amount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (months < 4 && this.Customer is IndividualCustomer)
            {
                throw new ArgumentException("There is no interest for the first 3 month for individual customer");
            }
            if (months < 3 && this.Customer is CompanyCustomer)
            {
                throw new ArgumentException("There is no interest for the first 2 month for company customer");
            }
            if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterestAmount(months - 3);
            }
            
            return base.CalculateInterestAmount(months - 2);
        }
    }
}