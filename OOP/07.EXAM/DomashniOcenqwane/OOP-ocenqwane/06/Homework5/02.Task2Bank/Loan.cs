using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // The loan class
    public class Loan :Account
    {
        public Loan(Client client, decimal balance, decimal interest)
            : base(client, balance, interest)
        {
        }

        public override void DepositMoney(decimal sumToDeposit)
        {
            base.DepositMoney(sumToDeposit);
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interestSum = 0;
            if (months <= 0)
                throw new ArgumentException("The period to calculate the interest for must be specified in positive integer number of months.");
            if (this.Client is IndividualClient)
            {
                if (months > 3)
                    interestSum += base.CalculateInterest(months - 3);
            }
            else if (this.Client is Company)
            {
                if (months > 2)
                    interestSum += base.CalculateInterest(months - 2);
            }
            return interestSum;
        }
    }
}
