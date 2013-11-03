using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // Interface for classes that support depositing money
    public interface IDepositable
    {
        void DepositMoney(decimal sum);
    }
}
