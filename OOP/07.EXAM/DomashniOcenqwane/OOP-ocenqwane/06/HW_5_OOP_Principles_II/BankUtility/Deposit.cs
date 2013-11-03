using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUtility
{
    public class Deposit:Account,IWithdrawable
    {
        public Deposit(CustomerType customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        void IWithdrawable.WithdrawMoney(decimal withdrawAmount)
        {
            if (withdrawAmount < 0)
            {
                throw new ArgumentException("Invalid withdraw amount!");
            }
            if (this.Balance>=withdrawAmount )
            {
                this.Balance -= withdrawAmount;
            }
            else
            {
                throw new ArgumentException("Insufficient funds!!!");
            }
        }
        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance>0 & this.Balance<1000)
            {
                return 0.0m;
            }
            else
            {
               return base.CalculateInterestAmount(months);
            }
        }
    }
}
