using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//I am reading all the things that I need to import

static class BookstoreComplexImporter
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../complex-books.xml");
        string xPathQuery = "/catalog/book";
        string xPathQueryReview = "/catalog/book/reviews/review";

        XmlNodeList bookstoresList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookstoreNode in bookstoresList)
        {

            string author = bookstoreNode.GetChildText("authors/author");

            string title = bookstoreNode.GetChildText("title");

            long? isbn = null;
            string isbnString = bookstoreNode.GetChildText("isbn");
            if (isbnString == null)
            {
                isbn = null;
            }
            else
            {
                isbn = Convert.ToInt64(isbnString);
            }

            decimal? price = null;
            string priceString = bookstoreNode.GetChildText("price");
            if (priceString == null)
            {
                price = null;
            }
            else
            {
                price = Convert.ToDecimal(priceString);
            }

            string webSite = bookstoreNode.GetChildText("web-site");

            string review = bookstoreNode.GetChildText("reviews/review");
            
            //BookstoreDAL.AddBookstore(author, title, isbn, price, webSite);
            AddBookstore(author, title, isbn, price, webSite , review);
        }

        XmlNodeList bookstoresListReview = xmlDoc.SelectNodes(xPathQueryReview);
        foreach (XmlNode bookstoreNode in bookstoresListReview)
        {
            var reviewAttribsAuthor = bookstoreNode.Attributes["author"];
            if (reviewAttribsAuthor != null)
            {
                string reviewAttAuthor = reviewAttribsAuthor.Value;
                Console.WriteLine(reviewAttAuthor);// Testing attribute author of Reviews
            }

            var reviewDate = bookstoreNode.Attributes["date"];
            if (reviewDate != null)
            {
                string reviewAttDate = reviewDate.Value;
                Console.WriteLine(reviewAttDate);// Testing attribute Date of Reviews
            }
            //BookstoreDAL.AddBookstore(author, title, isbn, price, webSite);
        }
    }

    private static void AddBookstore(string author, string title, long? isbn, decimal? price, string webSite, string review)
    {
        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", author, title, isbn, price, webSite, review);
    }

    private static string GetChildText(this XmlNode node, string name)
    {
        XmlNode childNode = node.SelectSingleNode(name);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText;
    }
}
