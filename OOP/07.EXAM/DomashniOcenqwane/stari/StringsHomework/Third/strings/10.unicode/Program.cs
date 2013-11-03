using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.unicode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text");
            string text = Console.ReadLine();

            foreach (char letter in text)
            {
                Console.Write("\\u{0:x4}",(int)letter);
            }
            Console.WriteLine();
        }
    }
}
