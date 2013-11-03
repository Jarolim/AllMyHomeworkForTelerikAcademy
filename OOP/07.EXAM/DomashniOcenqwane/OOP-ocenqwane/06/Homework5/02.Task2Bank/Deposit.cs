using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // The deposit class
    public class Deposit :Account, IDrawable
    {
        public Deposit(Client client, decimal balance, decimal interest)
            : base(client, balance, interest)
        {
        }

        // Methods for withdrawing and depositing money
        public decimal DrawSum(decimal sum)
        {
            if (sum < 0)
                throw new ArgumentException("You canno withdraw a negative amount of money."); 
            if (this.Balance >= sum)
            {
                this.Balance -= sum;
                return sum;
            }
            else
                throw new ArgumentException("You cannot withdraw more money from your deposit than you currently have.");
        }

        public override void DepositMoney(decimal sumToDeposit)
        {
            base.DepositMoney(sumToDeposit);
        }

        // Calculate Interest
        public override decimal CalculateInterest(int months)
        {
            if (months <= 0)
                throw new ArgumentException("The period to calculate the interest for must be specified in positive integer number of months.");
            if ((this.Balance > 0) && (this.Balance < 1000))
                return 0;
            return base.CalculateInterest(months);
        }
    }
}
