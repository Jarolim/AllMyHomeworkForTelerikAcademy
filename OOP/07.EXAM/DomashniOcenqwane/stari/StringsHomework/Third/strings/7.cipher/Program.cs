using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the string");
            string text = Console.ReadLine();
            Console.WriteLine("Input the cipher");
            string cipher = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int cP = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = cP; j < cipher.Length; j++)
                {
                    sb = sb.Append(text[i] | cipher[j]);
                    if (cP == cipher.Length - 1)
                    {
                        cP = 0;
                    }
                    else
                    {
                        cP = j + 1;
                    }
                    break;
                }
            }
        }
    }
}