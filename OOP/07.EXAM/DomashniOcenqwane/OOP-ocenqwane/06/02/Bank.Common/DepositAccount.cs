using System;

namespace Bank.Common
{
    public class DepositAccount : Account,
        IDepositable, IDrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
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

        public void WithDraw(decimal amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new ArgumentException("amount cant no be less then zero or less then balance");
            }
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance < 0 || this.Balance < 1000)
            {
                throw new Exception("This service is unable for balance less then 1000");
            }
            return base.CalculateInterestAmount(months);
        }

       
    }
}