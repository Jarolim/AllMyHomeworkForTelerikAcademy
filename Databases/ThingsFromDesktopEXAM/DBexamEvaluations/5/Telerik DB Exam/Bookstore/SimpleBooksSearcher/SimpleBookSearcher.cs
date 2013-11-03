using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using BookstoreData;

namespace SimpleBooksSearcher
{
    public static class SimpleBookSearcher
    {
        static void Main()
        {
            //Open xml file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");

            //Parse search query
            XmlNode queryNode = xmlDoc.SelectSingleNode("/query");
            string title = queryNode.GetChildText("title");
            string author = queryNode.GetChildText("author");
            string isbn = queryNode.GetChildText("isbn");

            //Find books
            List<Book> booksFound = BookstoreDAL.SimpleSearch(title, author, isbn);

            //Print results
            if (booksFound.Count > 0)
            {
                Console.WriteLine("{0} books found:", booksFound.Count);
                foreach (var book in booksFound)
                {
                    int bookReviewCount = BookstoreDAL.GetReviewCount(book.BookId);
                    string reviewCount = (bookReviewCount > 0) ? bookReviewCount.ToString() : "no";
                    Console.WriteLine("{0} --> {1} reviews", book.Title,reviewCount);
                }
            }
            else
            {
                Console.WriteLine("Noting found");
            }
        }

        private static string GetChildText(this XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
