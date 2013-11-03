using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Bookstore.Models;

namespace SimpleSearch
{
    class SimpleSearch
    {
        const string Author = "author";
        const string Title = "title";
        const string ISBN = "isbn";

        const string Query = @"..\..\simple-query.xml";
        const string Query1 = @"..\..\simple-query1.xml";
        const string Query2 = @"..\..\simple-query2.xml";

        static void Main()
        {
            var xmlSearch = new System.Xml.XmlDocument();

            //select one of the above Query, Query1
            xmlSearch.Load(Query1);
            
            var query = xmlSearch.SelectSingleNode("/query");
            
            var author = query[Author].GetText();
            var title = query[Title].GetText();
            var isbn = query[ISBN].GetText();
         
            var dbContext = new BookstoreDbContext();

            var queryLogEntry = new SearchLogEntry
            {
                Date = DateTime.Now,
                QueryXml = query.OuterXml
            };

            var foundBooks = GenerateQuery(author, title, isbn, dbContext);

            dbContext.SearchLog.Add(queryLogEntry);
            dbContext.SaveChanges();

            PrintResult(foundBooks);
        }

        private static void PrintResult(List<SimpleSearchResult> foundBooks)
        {
            if (foundBooks.Count() == 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.AppendFormat("{0} books found:\n", foundBooks.Count);
                foreach (var book in foundBooks)
                {
                    var countReviews = book.ReviewsCount.ToString();
                    
                    if (book.ReviewsCount == 0)
                    {
                        countReviews = "no";
                    } 

                    result.AppendFormat("{0} --> {1} reviews\n", book.Title, countReviews);
                }
                Console.WriteLine(result.ToString());
            }
        }

        private static List<SimpleSearchResult> GenerateQuery(string author, string title, string isbn, BookstoreDbContext dbContext)
        {
            var books = dbContext.Books.Include("Authors").Include("Reviews").AsQueryable();
            if (title != null)
            {
                books = books.Where(b => b.Title.ToLower() == title.ToLower());
            }
            if (isbn != null)
            {
                books = books.Where(b => b.ISBN == isbn);
            }

            if (author != null)
            {
                books = books.Where(b => b.Authors.Any(a => a.Name.ToLower() == author.ToLower()));
            }

            books = books.OrderBy(b => b.Title);
            var foundBooks = books.Select(b => new SimpleSearchResult
            {
                Title = b.Title,
                ReviewsCount = b.Reviews.Count
            }).ToList();

            return foundBooks;
        }
    }
}
