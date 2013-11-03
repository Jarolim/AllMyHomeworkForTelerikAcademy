using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUtility
{
    public class Loan:Account
    {
        public Loan(CustomerType customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer==CustomerType.Individual)
            {
                if (months<3)
                {
                    return 0.0m;
                }
                return base.CalculateInterestAmount(months - 3);
            }
            else
            {
                if (months<2)
                {
                    return 0.0m;
                }
                return base.CalculateInterestAmount(months - 2);
            }
        }
    }
}
