using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace FeedzillaConsumer
{
    internal class FeedzillaConsumer
    {
        static async void GetArticles(HttpClient httpClient, string queryString)
        {
            var response = await httpClient.GetAsync(string.Format("v1/articles/search.json?q={0}", queryString));
            var articlesFound = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ArticlesCollection>(articlesFound);

            PrintArticles(data);
        }

        static async void GetArticles(HttpClient httpClient, string queryString, int count)
        {
            var response = await httpClient.GetAsync(string.Format("v1/articles/search.json?q={0}&count={1}", queryString, count));
            var articlesFound = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ArticlesCollection>(articlesFound);

            PrintArticles(data);
        }

        static void PrintArticles(ArticlesCollection data)
        {
            Console.WriteLine();

            foreach (var article in data.Articles)
            {
                Console.WriteLine(
                    "Title:\n{0}\nUrl:\n{1}\n",
                    article.Title,
                    article.Url);
            }
        }

        private static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/");

            Console.WriteLine("Query String: ");
            string queryString = Console.ReadLine();

            //GetArticles(httpClient, queryString);
            //System.Threading.Thread.Sleep(3000);

            GetArticles(httpClient, queryString, 4);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
