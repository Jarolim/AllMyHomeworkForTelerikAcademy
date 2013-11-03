using System;
using System.Linq;

namespace Bank.Common
{
    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value;
            }
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            return months * this.InterestRate / 100 * this.Balance;
        }

        public override string ToString()
        {
            return string.Format("{0}\nAccount Info: balance {1}, interestRate {2}", this.Customer, this.Balance, this.InterestRate);
        }
    }
}