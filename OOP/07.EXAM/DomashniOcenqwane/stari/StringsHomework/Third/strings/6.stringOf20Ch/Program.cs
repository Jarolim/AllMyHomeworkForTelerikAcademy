using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.stringOf20Ch
{
    class Program
    {
        static void Main(string[] args)
        {

           
            bool flag = true;

            while (flag == true)
            {
                string text = Console.ReadLine();
                if (text.Length < 20)
                {
                    text = text + new string('*', (20 - text.Length));
                    Console.WriteLine(text);
                    flag = false;
                }
                else
                {
                    if (text.Length == 20)
                    {
                        Console.WriteLine(text);
                        flag = false;
                    }
                    else
                    {
                        if (text.Length > 20)
                        {
                            Console.WriteLine("The text is too big to be an input. Try again");
                            flag = true;
                        }
                    }
                }
            }
        }
    }
}
