using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace DictionaryRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                while (true)
                {
                    PrintMenu();
                    ProcessUserCommand(redisClient);
                }
            }
        }
         private static void PrintMenu()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("A. Search for translation"); //Search
            Console.WriteLine("B. List all words"); //Read
            Console.WriteLine("C. Edit a listed word"); //Update
            Console.WriteLine("D. Remove a listed word"); //Delete
            Console.WriteLine("E. Add word");//Create
            Console.WriteLine("X. Exit");//Exit
        }

        private static void ProcessUserCommand(RedisClient words)
        {
            string loweredInput = Console.ReadLine().ToLower();
            if (loweredInput == "a")
            {
                Utilities.SreachWord(words);
            }
            else if (loweredInput == "b")
            {
                byte[][] dictionary = words.HKeys("words");
                if (dictionary.GetLength(0) != 0)
                {
                    foreach (var wordAsArray in dictionary)
                    {
                        string word = Extensions.StringFromByteArray(wordAsArray);
                        Console.WriteLine(word);
                    }
                }
                else
                {
                    Console.WriteLine("There has no words in dictionary");
                }
            }
            else if (loweredInput == "c")
            {
                Utilities.EditWord(words);
            }
            else if (loweredInput == "d")
            {
                Utilities.RemoveWords(words);
            }
            else if (loweredInput == "e")
            {
                Utilities.AddWord(words);
            }
            else if (loweredInput == "x")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong command");
            }
        }
    }
}
