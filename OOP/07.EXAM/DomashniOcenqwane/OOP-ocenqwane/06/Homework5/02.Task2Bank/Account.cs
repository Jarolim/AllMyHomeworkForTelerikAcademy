using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // Abstract class Account implementing IDepositable as all types of Accounts support depositing money
    public abstract class Account :IDepositable
    {
        // Fields and properties
        private Client client;

        public Client Client
        {
            get { return client; }
            protected set { client = value; }
        }

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            protected set {
                if (value < 0)
                    throw new ArgumentException("Balance cannot become negative.");
                balance = value; 
            }
        }

        private decimal interestRate;

        public decimal InterestRate
        {
            get { return interestRate; }
            protected set {
                if (value < 0)
                    throw new ArgumentException("You cannot have a negative interest rate.");
                interestRate = value; 
            }
        }

        // Protected constructor
        protected Account(Client client, decimal balance, decimal interest)
        {
            this.Client = client;
            this.Balance = balance;
            this.InterestRate = interest;
        }

        // Virtual methods for depositing and calculating interest
        public virtual void DepositMoney(decimal sumToDeposit)
        {
            if (sumToDeposit < 0)
                throw new ArgumentException("You cannot deposit a negative amount of money.");
            this.Balance+=sumToDeposit;
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months <= 0)
                throw new ArgumentException("The period to calculate the interest for must be specified in positive integer number of months.");
            return months * this.InterestRate*this.Balance;
        }

        // Overriding ToString
        public override string ToString()
        {
            return String.Format("Type: {0}, Balance:{1}, Interest: {2} Client:{3}",this.GetType().Name,this.Balance, this.InterestRate, this.Client);
        }

    }
}
