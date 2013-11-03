using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _2.MillionsArticlesOrderedMultiDictionary
{
    public class Article : IComparable<Article>
    {
        public int Barcode { get; set; }
        public string Vedndor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Article(int barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vedndor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(Article otherArticle)
        {
            return this.Price.CompareTo(otherArticle.Price);
        }
    }

    class MillionsArticlesOrderedMultiDictionary
    {
        static void Main()
        {
            Article[] articles = {new Article(13447311,"Billa","Кюфте",16M),
                                     new Article(13447311,"Lidl","Кетчуп",17.99M),
                                     new Article(13447311,"CBA","Бекон",13.55M),
                                     new Article(13447311,"Jumbo","Боклук",15.00M),
                                     new Article(13447311,"HippoLand","Чорап",13M),
                                     new Article(13447311,"Ikea","Бъчва",17M)};

            OrderedMultiDictionary<decimal, Article> catalog = new OrderedMultiDictionary<decimal, Article>(true);

            foreach (var article in articles)
            {
                catalog.Add(article.Price, article);
            }

            var pricesRange = catalog.FindAll(x => x.Key >= 10 && x.Key <= 20);
            foreach (var item in pricesRange)
            {
                string items = "";
                int count = 0;
                foreach (var article in item.Value)
                {
                    count += 1;
                    items += "article" + count + ": " + article.Title + " " + article.Vedndor + " " + article.Barcode + ";\n";
                }

                Console.WriteLine("Price: {0} - articles: {1}",
                    item.Key, items);
            }
        }
    }
}
