using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Task2Bank
{
    // Interface for classes (Deposit) that support withdrawing money
    public interface IDrawable
    {
        decimal DrawSum(decimal sum);
    }
}
