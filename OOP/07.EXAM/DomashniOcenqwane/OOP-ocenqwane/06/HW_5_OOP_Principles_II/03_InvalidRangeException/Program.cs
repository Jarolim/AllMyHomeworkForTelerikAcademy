using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_InvalidRangeException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number in range [1..100]");
            string inputNumber = Console.ReadLine();
            try
            {
                int number = int.Parse(inputNumber);
                CheckNumberDate(number);
                Console.WriteLine("Your number is {0}",number);
            }
            catch (OverflowException ofe)
            {

                throw new InvalidRangeException<int>("Invalid number!",inputNumber, 1, 100, ofe);
            }

            Console.WriteLine("Enter a date in range [1.1.1980 .. 31.12.2013]");
            string inputDate = Console.ReadLine();
            try
            {
                DateTime number = DateTime.Parse(inputDate);
                CheckNumberDate(number);
                Console.WriteLine("Your date is {0}", number);
            }
            catch (OverflowException ofe)
            {

                throw new InvalidRangeException<int>("Invalid number!",inputNumber, 1, 100, ofe);
            }

        }

        private static void CheckNumberDate(object numberOrDate)
        {
            if (numberOrDate is int)
            {
                if ((int)numberOrDate < 1 || (int)numberOrDate > 100)
                {
                    throw new InvalidRangeException<int>("Invalid number!", numberOrDate.ToString(), 1, 100);
                }
            }
            if (numberOrDate is DateTime)
            {
                DateTime begin = new DateTime(1980,1, 1);
                DateTime end = new DateTime(2013,12,31);
                if ((DateTime)numberOrDate<begin||(DateTime)numberOrDate>end)
                {
                    throw new InvalidRangeException<DateTime>("Invalid date!", numberOrDate.ToString(), begin, end);
                }
            }
            
        }
    }
}
