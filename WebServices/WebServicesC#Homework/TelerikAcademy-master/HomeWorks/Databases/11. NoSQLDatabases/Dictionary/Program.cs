using System;
using MongoDB.Driver;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var dictionaryDb = mongoServer.GetDatabase("Dictionary");
            var words = dictionaryDb.GetCollection<Word>("Words");

            while (true)
            {
                PrintMenu();
                ProcessUserCommand(words);
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

        private static void ProcessUserCommand(MongoCollection words)
        {
            string loweredInput = Console.ReadLine().ToLower();
            if (loweredInput == "a")
            {
                Utilities.SreachWord(words);
            }
            else if (loweredInput == "b")
            {
                var dictionary = words.FindAllAs<Word>();
                foreach (var word in dictionary)
                {
                    Console.WriteLine(word.Value);
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
