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
            int N = int.Parse(Console.ReadLine());
            List<char> ggg = new List<char>();
            words = new string[N];


            for (int i = 0; i < N; i++)
            {
                words[i] = Console.ReadLine();
                var bla = words[i].ToCharArray();
            }

            for (int i = 0; i < N; i++)
            {
                currentWord.Append(words[i].ToCharArray());
            }

            for (int i = 0; i < currentWord.Length; i++)
            {

                    if (currentWord[i] == currentWord[i+1])
                    {
                        currentWord.Remove(i,1);
                    }

            }
            Console.WriteLine(currentWord[4]);

            Console.WriteLine(currentWord);
        }
    }
}
