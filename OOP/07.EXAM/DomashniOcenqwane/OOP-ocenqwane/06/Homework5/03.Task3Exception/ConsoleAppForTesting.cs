using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Task3Exception
{
    class ConsoleAppForTesting
    {
        static void Main()
        {
            // Creating an exception for int
            InvalidRangeException<int> exceptionInt = new InvalidRangeException<int>(1, 100, "not in the interval [1,100].");
            int[] arrayInt = new int[6] { -17, 14, 26, 89, 1112,25252 };
            foreach (int c in arrayInt)
            {
                try
                {
                    if ((c < exceptionInt.Start) || (c > exceptionInt.End))
                        throw exceptionInt;
                }
                catch (InvalidRangeException<int> exc)
                {
                    Console.WriteLine("{0} is {1}", c, exc.ErrorMessage);
                }
            }

            // Creating an exception for DateTime
            InvalidRangeException<DateTime> exceptionDate = new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31), "not in the required interval");
            DateTime[] arrayDates = new DateTime[3] { new DateTime(1456, 11, 12), new DateTime(1990, 12, 24), new DateTime(2014, 1, 1) };
            foreach (DateTime c in arrayDates)
            {
                try
                {
                    if ((DateTime.Compare(c, exceptionDate.Start) < 0) || (DateTime.Compare(c, exceptionDate.End) > 0))
                        throw exceptionDate;
                }
                catch (InvalidRangeException<DateTime> exc)
                {
                    Console.WriteLine("{0}.{1}.{2} is {3}", c.Day, c.Month, c.Year, exc.ErrorMessage);
                }
            }
        }
    }
}
