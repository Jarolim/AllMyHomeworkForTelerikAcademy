using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.reversedString
{
    class Program
    {
        static string ReversedText(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input the string");
            string text = Console.ReadLine();
            Console.WriteLine("Reversed text:");
            Console.WriteLine(ReversedText(text));



        }
    }
}
