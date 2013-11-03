using System;

namespace Bank.Common
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
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
            if (months <= 0)
            {
                throw new ArgumentException("Month can not be 0 or less then 0");
            }
            if (months < 7 && this.Customer is IndividualCustomer)
            {
                throw new ArgumentException("There is no interest for the first 6 month for individual customer");
            }
           
            if (this.Customer is CompanyCustomer && months < 13)
            {
                return ((this.InterestRate / 2) * months) / 100;
            }
            if (this.Customer is CompanyCustomer && months > 12)
            {
                decimal finalRate = (this.InterestRate / 2) * 12 / 100 * this.Balance;
                return finalRate += base.CalculateInterestAmount(months - 12);
            }
                        
            return base.CalculateInterestAmount(months - 6);
        }
    }
}