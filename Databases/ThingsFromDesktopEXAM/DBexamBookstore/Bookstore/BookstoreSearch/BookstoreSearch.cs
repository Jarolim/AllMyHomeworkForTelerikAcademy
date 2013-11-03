using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Data;

static class BookstoreSearch
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../simple-query.xml");
        string title = xmlDoc.GetChildText("/query/title");
        string author = xmlDoc.GetChildText("/query/author");
        string isbn = xmlDoc.GetChildText("/query/isbn");
        //Console.WriteLine(title);
        //Console.WriteLine(author);

        var books = BookstoreDAL.FindBooksByAuthor(author);
        if (books.Count > 0)
        {
            Console.WriteLine("{0} books found:", books.Count);
            foreach (var book in books)
            {
                int reviewCount = book.Reviews.Count;
                string noReviews = "no";

                if (reviewCount == 0)
                {
                    Console.WriteLine("{0} --> {1} reviews", book.Title, noReviews);
                }
                else
                { 
                    Console.WriteLine("{0} --> {1} reviews", book.Title, reviewCount);
                }
            }
        }
        else
        {
            Console.WriteLine("Nothing Found");
        }
    }

    private static string GetChildText(this XmlNode node, string xpath)
    {
        XmlNode childNode = node.SelectSingleNode(xpath);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText.Trim();
    }
}

