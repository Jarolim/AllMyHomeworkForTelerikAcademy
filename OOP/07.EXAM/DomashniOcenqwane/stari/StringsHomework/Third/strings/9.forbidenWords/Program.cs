using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.forbidenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text");
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Input the number of forbiden words");
            int n = int.Parse(Console.ReadLine());
            string[] forbiden = new string[n];
            for (int j = 0; j < forbiden.Length; j++)
            {
                Console.WriteLine("Input a word");
                forbiden[j] = Console.ReadLine();
            }
            int i = 0;
            int startIndex = 0;
            string help = "";
            int begin = 0;
            int start = 0;
            foreach (string word in forbiden)
            {
                begin = 0;
                startIndex = 0;
                while (startIndex != -1)
                {
                    startIndex = text.IndexOf(word, begin);
                    if (startIndex > 0)
                    {
                        for (i = start; i < startIndex; i++)
                        {
                            sb = sb.Append(text[i]);
                        }
                        help = word;
                        for (i = startIndex; i < startIndex + help.Length; i++)
                        {
                            sb = sb.Append("*");
                        }
                        start = i;
                    }
                    else
                    {
                        if (startIndex == 0)
                        {
                            help = word;
                            for (i = 0; i < help.Length; i++)
                            {
                                sb = sb.Append("*");
                            }
                            start = i;
                        }
                    }
                    begin = startIndex + 1;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
