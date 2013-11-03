using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.upperCase
{
    class Program
    {

        static void Upcase(string text, string open, string close)
        {
            StringBuilder sb = new StringBuilder();
            string[] arr = text.Split();
            string help = "";
            int index = 0;
            int index2 = -9;

            while ((index != -1) || (index2 != -1))
            {
                index = text.IndexOf(open, index2 + 9);
                if (index != -1)
                {
                    for (int i = (index2 + 9); i < index; i++)
                    {
                        sb = sb.Append(text[i]);
                    }
                }
                else
                {
                    for (int i = text.LastIndexOf(close) + 9; i < text.Length; i++)
                    {
                        sb = sb.Append(text[i]);
                    }
                    Console.WriteLine(sb);
                    return;
                }
                index2 = text.IndexOf(close, index);
                help = text.Substring(index + 8, index2 - (index + 8));
                help = help.ToUpper();
                if (index2 != -1)
                {
                    for (int i = 0; i < help.Length; i++)
                    {
                        sb = sb.Append(help[i]);
                    }
                }
            }
        }
    
        static void Main(string[] args)
        {
            Console.WriteLine("Input the string");
            string text = Console.ReadLine();
            string open = "<upcase>";
            string close = "</upcase>";
            Upcase(text, open, close);
        }
    }
}
