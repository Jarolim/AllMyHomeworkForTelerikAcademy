/*Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.  * Keep the elements of the list in an array with fixed capacity which is given as parameter in  * the class constructor. Implement methods for adding element, accessing element by index, removing  * element by index, inserting element at given position, clearing the list, finding element by its value  * and ToString(). Check all input parameters to avoid accessing elements at invalid positions.Implement auto-grow functionality: when the internal array is full, create a new array of double size and  * move all elements to it.
 Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal 
 * element in the  GenericList<T>. You may need to add a generic constraints for the type T.*/


using System;
using System.Linq;

namespace GenericList
{
    class GenericListTests
    {
        static void Main()
        {
            try
            {
                int position;
                GenericList<string> myList = new GenericList<string>(5);               
                for (int i = 0; i < 5; i++)
                {
                    myList.Add("string" + (i + 1));
                }
                Console.WriteLine(myList);

                position = 1;
                Console.WriteLine("Remove element in position {0}",position); 
                myList.Remove(position);
                Console.WriteLine(myList);

                Console.WriteLine("Add element 'test' in position {0}", position); 
                myList.InsertAt("'test'", position);
                Console.WriteLine(myList);

                Console.WriteLine("Add element at end");
                myList.Add("test");
                Console.WriteLine(myList);
                for (int i = 0; i < 3; i++)
                {
                    myList.Add("test" + i);
                }
                Console.WriteLine(myList);
                Console.WriteLine("the count = " + myList.Count);
                Console.WriteLine("the capacity = " + myList.Length);

                myList.Add("anotherTest");
                Console.WriteLine();
                Console.WriteLine(myList);
                Console.WriteLine("the count = " + myList.Count);
                Console.WriteLine("the capacity = " + myList.Length);
                Console.WriteLine("index of element <test> is {0}",myList.IndexOf("test"));


                
                //Console.WriteLine(myList.Max(0));
                //Console.WriteLine(myList.Min(0));
                Console.WriteLine();
                GenericList<int> intList = new GenericList<int>(5);
                for (int i = 0; i < 10; i++)
                {
                    intList.Add(i);
                }

                //Task8.
                //intList.Add(256);
                //intList.Add(-256);
                //intList.Add(0);

                Console.WriteLine(intList);
                Console.WriteLine("Max is " + intList.Max(0));
                Console.WriteLine("Min is " + intList.Min(0));

                GenericList<float> floatList = new GenericList<float>(0);
                floatList.Add(5.6f);
                Console.WriteLine(floatList);

            }
            catch(SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
