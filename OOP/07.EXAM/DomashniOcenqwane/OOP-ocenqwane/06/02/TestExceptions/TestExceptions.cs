using System;
using InvalidRangeException.Common;

namespace TestExceptions
{
    class TestExceptions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int number = Int32.Parse(Console.ReadLine());
            DateTime date = new DateTime(2014, 1, 1);
            try
            {
                doSomething1(date);
                doSomething(number);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{0} - Expected Range[{1} to {2}]", ex.Message, ex.MinValue, ex.MaxValue);
            }
            catch (InvalidRangeException<DateTime> ex)
            {

                Console.WriteLine("{0} - Expected Range[{1} to {2}]", ex.Message, ex.MinValue.ToShortDateString(), ex.MaxValue.ToShortDateString());
            }
        }

        private static void doSomething1(DateTime date)
        {
            if (date.Year < 1980 || date.Year > 2013)
            {
                throw new InvalidRangeException<DateTime>("Argument out of range", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
        }
        
        private static void doSomething(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new InvalidRangeException<int>("Argument out of range", 1, 100);
            }
        }
    }
}