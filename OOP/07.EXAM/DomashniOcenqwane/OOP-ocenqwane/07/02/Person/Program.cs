using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person marin = new Person("Marin", 15);
            Person peter = new Person("Peter", null);

            Console.WriteLine(marin.ToString());
            Console.WriteLine(peter.ToString());
        }
    }
}
