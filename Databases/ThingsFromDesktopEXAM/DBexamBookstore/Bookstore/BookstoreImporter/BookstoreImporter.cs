using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

static class BookstoreImporter
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../simple-books.xml");
        string xPathQuery = "/catalog/book";

        XmlNodeList bookstoresList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookstoreNode in bookstoresList)
        {
            string author = bookstoreNode.GetChildText("author");

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

            BookstoreDAL.AddBookstore(author, title, isbn, price, webSite);
        }
    }

    //private static void AddBookstore(string author, string title, string isbn, string price, string webSite)
    //{
    //    Console.WriteLine("{0} {1} {2} {3} {4}", author, title, isbn, price, webSite);
    //}

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


