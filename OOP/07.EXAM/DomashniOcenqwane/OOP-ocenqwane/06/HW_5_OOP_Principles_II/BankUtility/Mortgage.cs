using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUtility
{
    public class Mortgage:Account
    {
        public Mortgage(CustomerType customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer==CustomerType.Individual)/*Mortgage accounts have ½ interest for the first 12 months 
                                                        * for companies and no interest for the first 6 months for individuals.*/

            {
                if (months<=6)
                {
                    return 0.0m;
                }
                else
                {
                   return base.CalculateInterestAmount(months-6);
                }
            }
            else
            {
                if (months<=12)
                {
                    return base.CalculateInterestAmount(months) / 2;
                }
                else
                {
                    return (base.CalculateInterestAmount(months-12)+base.CalculateInterestAmount(12)/2);
                }
            }
        }
    }
}
