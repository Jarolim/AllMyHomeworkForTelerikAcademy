using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Dictionary
{
    public static class Utilities
    {
        public static void EditWord(MongoCollection words)
        {
            Console.Write("Enter word for edit: ");
            string editWord = Console.ReadLine().ToLower();
            Console.Write("Enter new translation: ");
            string translation = Console.ReadLine().ToLower();
            var searched = words.AsQueryable<Word>().FirstOrDefault(w => w.Value == editWord);
            if (searched != null)
            {
                var update = Update.Set("Translation", translation);
                var query = Query.EQ("_id", searched.Id);
                words.Update(query, update);
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void RemoveWords(MongoCollection words)
        {
            Console.Write("Enter word for remove: ");
            string editWord = Console.ReadLine().ToLower();
            var searched = words.AsQueryable<Word>().FirstOrDefault(w => w.Value == editWord);
            if (searched != null)
            {
                var query = Query.EQ("_id", searched.Id);
                words.Remove(query);
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void SreachWord(MongoCollection words)
        {
            Console.Write("Enter word for translation: ");
            string searchedWord = Console.ReadLine().ToLower();
            var searched = words.AsQueryable<Word>().FirstOrDefault(w => w.Value == searchedWord);
            if (searched != null)
            {
                Console.WriteLine("Word: {0}\nTranslation: {1}", searched.Value, searched.Translation);
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void AddWord(MongoCollection words)
        {
            Console.Write("Enter word: ");
            string loweredWordt = Console.ReadLine().ToLower();
            Console.Write("Enter translation: ");
            string loweredTranslation = Console.ReadLine().ToLower();
            Word newWord = new Word(loweredWordt, loweredTranslation);

            int countWords = words.AsQueryable<Word>().Where(w => w.Value == newWord.Value).Count();
            if (countWords > 0)
            {
                Console.WriteLine("This word already exist");
            }
            else
            {
                words.Insert<Word>(newWord);
            }
        }
    }
}
