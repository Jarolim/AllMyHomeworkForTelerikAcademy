using System;
using System.Linq;
using System.Xml;
using BookstoreData;

static class SimpleBooksImorter
{
    static void Main()
    {
        //Open xml file
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../simple-books.xml");

        //Create query to xml file
        string xPathQuery = "/catalog/book";
        XmlNodeList bookList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookNode in bookList)
        {
            //Read inforamtion from xml file for each book
            string author = bookNode.GetChildText("author");
            ArgumentExceptionThrower(author, "author");

            string title = bookNode.GetChildText("title");
            ArgumentExceptionThrower(title, "title");

            string isbnAsString = bookNode.GetChildText("isbn");
            long? isbn = (isbnAsString != null) ? long.Parse(isbnAsString) : (long?)null;
            string priceAsString = bookNode.GetChildText("price");
            decimal? price = (priceAsString != null) ? decimal.Parse(priceAsString) : (decimal?)null;

            //Save the book in Bookstore database
            BookstoreDAL.AddBook(title, author, isbn, price);
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

    private static void ArgumentExceptionThrower(object o, string missingParameter)
    {
        if (o == null)
        {
            throw new ArgumentNullException(missingParameter);
        }
    }
}
