using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder test = new StringBuilder();
            test.Append("ABCDIFGH");
            Console.WriteLine(test.SubString(5, 2).ToString());
      
        }
    }
}
