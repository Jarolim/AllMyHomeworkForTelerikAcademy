// tasks 5, 6 and 7!

using System;

namespace _05GenericClass
{
    class Program
    {
        static void Main()
        {
            GenericListClass<int> testList = new GenericListClass<int>(6);
            testList.Add(58);                      // test Add method
            testList.Add(425);
            testList.Add(5);
            Console.WriteLine(testList[0]);  

            testList.Remove(1);                      // test remove method
            Console.WriteLine(testList[1]);

            testList.InsertElement(1, 100);          // test insert method
            Console.WriteLine("Inserted element: {0}", testList[1]);
            Console.WriteLine(testList[2]);

            testList.Clear();
            Console.WriteLine("Cleared!");

            testList.Add(8);                       
            Console.WriteLine(testList[0]);

            Console.WriteLine("Test finding an index of an element by value:\n {0}", testList.FindByValue(8));

            testList.Add(52);
            testList.Add(23);
            Console.WriteLine("Test ToString override:\n {0}", testList.ToString());

            testList.Add(4);           // problem 6 test
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.Add(8);
            Console.WriteLine("If here is an element the array size is doubled: {0}", testList[7]);

            int minValue = testList.Min<int>();           // problem 7 test /min should be 4/
            Console.WriteLine("Min value in the array: {0}", minValue);

            int maxValue = testList.Max<int>();           // max should be 52
            Console.WriteLine("Max value in the array: {0}", maxValue);
        }
    }
}
