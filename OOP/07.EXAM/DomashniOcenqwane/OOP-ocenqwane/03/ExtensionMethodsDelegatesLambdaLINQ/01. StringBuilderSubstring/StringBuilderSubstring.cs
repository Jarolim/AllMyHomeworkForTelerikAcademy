using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderSubstring
{
    class StringBuilderSubstring
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder example = new StringBuilder("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                                          "Etiam velit arcu, ultricies et facilisis at, placerat ac ante. " +
                                                          "Integer sed metus vitae ipsum fermentum interdum. " +
                                                          "Praesent ac nisl erat, eget ultricies urna. " +
                                                          "Ut egestas adipiscing arcu quis rhoncus. " +
                                                          "Etiam adipiscing sodales interdum. " +
                                                          "Cras vitae massa id sem imperdiet bibendum. " +
                                                          "Aenean lobortis pretium magna. " +
                                                          "Nulla nulla nisi, fringilla vel vehicula vel, tempor eu mi.");

                //StringBuilder substring = example.Substring(-1, 2); // exeption
                //StringBuilder substring = example.Substring(4344345, 2); // exeption
                //StringBuilder substring = example.Substring(1, -1); // exeption
                //StringBuilder substring = example.Substring(6, 4543875); // exeption
                StringBuilder substring = example.Substring(6, 5); // OK

                Console.WriteLine(substring.ToString());
            }

            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
