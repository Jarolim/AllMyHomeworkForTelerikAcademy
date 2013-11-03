using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUtility
{
    public abstract class Account
    {
        private CustomerType customer;
        private decimal balance;
        private decimal interestRate;

        public Account(CustomerType customer, decimal balance, decimal interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public CustomerType Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value<0.0m)
                {
                    throw new ArgumentException("Invalid interest rate!");
                }
                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            return this.InterestRate * months;
        }

        public void DepositMoney(decimal depositAmount)
        {
            if (depositAmount < 0)
            {
                throw new ArgumentException("Invalid deposit amount!");
            }
            this.Balance += depositAmount;
        }
    }
}
