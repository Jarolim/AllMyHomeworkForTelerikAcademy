using System;
using System.Linq;

namespace Bank.Common
{
    interface IDepositable
    {
        void Deposit(decimal amount);
    }
}
