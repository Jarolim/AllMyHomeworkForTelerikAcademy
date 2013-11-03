using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankUtility
{
    interface IWithdrawable
    {
        void WithdrawMoney(decimal withdrawAmount);
    }
}
