using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.extractingASentence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the text");
            string text = Console.ReadLine();
            string search = "in ";
            StringBuilder sb = new StringBuilder();
            int start = 0;
            int indexIn = text.IndexOf(search, StringComparison.InvariantCultureIgnoreCase);
            int indexDot = text.IndexOf('.');
            string help ="";
            int end = 0;

            while ((indexIn != -1) & (indexDot != -1))
            {
                if (indexIn != -1)
                {
                    if (indexDot != -1)
                    {
                        sb = sb.Append(text.Substring(start, (indexDot - start + 1)));
                        indexIn = text.IndexOf(search, indexDot, StringComparison.InvariantCultureIgnoreCase);
                        if (indexIn != -1)
                        {
                            start = text.LastIndexOf('.', indexIn);
                            start = start + 1;
                            end = text.IndexOf('.', start + 1);
                        }

                    }
                }
                indexDot = end;
            }
            Console.WriteLine(sb);
        }
    }
}
