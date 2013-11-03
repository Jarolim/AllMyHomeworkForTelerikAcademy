using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bla.MostCommon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> firstNames = new Dictionary<string, int>();
            Dictionary<string, int> lastNames = new Dictionary<string, int>();
            Dictionary<string, int> years = new Dictionary<string, int>();
            Dictionary<string, int> eyes = new Dictionary<string, int>();
            Dictionary<string, int> hairs = new Dictionary<string, int>();
            Dictionary<string, int> heights = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] characteristics = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                AddElementToDict(characteristics[0], firstNames);
                AddElementToDict(characteristics[1], lastNames);
                AddElementToDict(characteristics[2], years);
                AddElementToDict(characteristics[3], eyes);
                AddElementToDict(characteristics[4], hairs);
                AddElementToDict(characteristics[5], heights);
            }

            Console.WriteLine(SearchElement(firstNames));
            Console.WriteLine(SearchElement(lastNames));
            Console.WriteLine(SearchElement(years));
            Console.WriteLine(SearchElement(eyes));
            Console.WriteLine(SearchElement(hairs));
            Console.WriteLine(SearchElement(heights));

        }

        private static void AddElementToDict(string key, Dictionary<string, int> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 1);
            }
            else 
            {
                dictionary[key]++;
            }
        }

        private static string SearchElement(Dictionary<string, int> dictionary)
        {
            string result = string.Empty;

            int max = int.MinValue;

            foreach (var item in dictionary)
            {
                if (item.Value > max)
                {
                    result = item.Key;
                    max = item.Value;
                }
                if (item.Value == max)
                {
                    if (result.CompareTo(item.Key) > 0)
                    {
                        result = item.Key;
                    }
                }
            }

            return result;
        }

    }
}
