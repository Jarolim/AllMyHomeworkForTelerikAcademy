using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.substring
{
    class Program
    {
        static int Substring(string text, string substring)
        {
            int index = text.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase);
            int counter = 0;
            while (index != -1)
            {
                index = text.IndexOf(substring, index + 1, StringComparison.InvariantCultureIgnoreCase);
                counter = counter + 1;
            }
            return counter;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input the text");
            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine("Input the substring");
            string substring = Console.ReadLine();
            Console.WriteLine(Substring(text, substring));
        }
    }
}
