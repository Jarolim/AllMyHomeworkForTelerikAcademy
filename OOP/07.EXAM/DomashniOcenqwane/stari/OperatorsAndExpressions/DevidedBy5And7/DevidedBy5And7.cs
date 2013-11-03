using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevidedBy5And7
{
    class DevidedBy5And7
    {
        static void Main(string[] args)
        {
            bool result;
            int numberToBeChecked = 0;
            result = ((numberToBeChecked % 5) == 0) & ((numberToBeChecked % 7) == 0);
            Console.WriteLine(result);
        }
    }
}
