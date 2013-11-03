using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.reversingWordsInASentence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the sentence");
            string text = "C# is not C++, not PHP and not Delphi!";
            StringBuilder sb = new StringBuilder();
            string[] reversed = new string[text.Length];
            int j = text.Length;


            foreach (string word in text.Split())
            {
                for (int i = j - 1; i >= 0; i--)
                {
                    reversed[i] = word;
                    j = j - 1;
                    break;
                }
            }
            for (int i = 0; i < reversed.Length; i++)
            {
                Console.Write(reversed[i]);
            }
        }
    }
}
