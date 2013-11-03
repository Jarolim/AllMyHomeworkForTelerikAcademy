using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace DictionaryRedis
{
    public static class Utilities
    {
        public static void EditWord(RedisClient words)
        {
            Console.Write("Enter word for edit: ");
            string editWord = Console.ReadLine().ToLower();
            Console.Write("Enter new translation: ");
            string translation = Console.ReadLine().ToLower();
            long countWords = words.HExists("words", Extensions.ToAsciiCharArray(editWord));
            if (countWords>0)
            {
                words.HSet("words", Extensions.ToAsciiCharArray(editWord), Extensions.ToAsciiCharArray(translation));
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void RemoveWords(RedisClient words)
        {
            Console.Write("Enter word for remove: ");
            string deleteWord = Console.ReadLine().ToLower();
            long countWords = words.HExists("words", Extensions.ToAsciiCharArray(deleteWord));
            if (countWords>0)
            {
                words.HDel("words", Extensions.ToAsciiCharArray(deleteWord));
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void SreachWord(RedisClient words)
        {
            Console.Write("Enter word for translation: ");
            string searchedWord = Console.ReadLine().ToLower();
            long countWords = words.HExists("words", Extensions.ToAsciiCharArray(searchedWord));
            if (countWords > 0)
            {
                var translation = words.HGet("words", Extensions.ToAsciiCharArray(searchedWord));
                Console.WriteLine("Word: {0}\nTranslation: {1}", searchedWord, Extensions.StringFromByteArray(translation));
            }
            else
            {
                Console.WriteLine("This word is not exist");
            }
        }

        public static void AddWord(RedisClient words)
        {
            Console.Write("Enter word: ");
            string loweredWord = Console.ReadLine().ToLower();
            Console.Write("Enter translation: ");
            string loweredTranslation = Console.ReadLine().ToLower();

            long countWords = words.HExists("words", Extensions.ToAsciiCharArray(loweredWord));
            if (countWords > 0)
            {
                Console.WriteLine("This word already exist");
            }
            else
            {
                words.HSetNX("words", Extensions.ToAsciiCharArray(loweredWord), Extensions.ToAsciiCharArray(loweredTranslation));
            }
        }
    }
}
