using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class TestGenericList
    {
        static void Main()
        {
            GenericList<double> genList = new GenericList<double>(8);
            genList.Add(1.234);
            genList.Add(3.2);
            genList.Add(67.4);
            genList.InsertAt(76.1, 3);
            genList.Add(11.2);
            genList.InsertAt(222.25, 3);
            genList.InsertAt(123.01, 7);
            Console.WriteLine(genList.ToString());
        }
    }
}
