using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.RecoverMessage
{
    class Program
    {
        static string[] words;


        static void Main(string[] args)
        {
            StringBuilder currentWord = new StringBuilder();
            StringBuilder sbBla = new StringBuilder();
            int N = int.Parse(Console.ReadLine());
            List<char> ggg = new List<char>();
            words = new string[N];

            for (int i = 0; i < N; i++)
            {
                words[i] = Console.ReadLine();
            }

            Array.Sort(words);

            for (int i = 0; i < words.Length; i++)
            {
                currentWord.Append(words[i]);
            }

            var bla = currentWord.ToString();

            var blabla = bla.ToCharArray();

            Array.Sort(blabla);


            Console.WriteLine(blabla);
        }
    }
}
