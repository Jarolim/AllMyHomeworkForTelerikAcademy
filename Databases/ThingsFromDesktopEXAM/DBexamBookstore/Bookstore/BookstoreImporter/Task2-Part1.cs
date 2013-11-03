//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//static class BookstoreImporter
//{
//    static void Main()
//    {
//        XmlDocument xmlDoc = new XmlDocument();
//        xmlDoc.Load("../../simple-books.xml");
//        string xPathQuery = "/catalog/book";

//        XmlNodeList bookstoresList = xmlDoc.SelectNodes(xPathQuery);
//        foreach (XmlNode bookstoreNode in bookstoresList)
//        {
//            string author = bookstoreNode.GetChildText("author");

//            string title = bookstoreNode.GetChildText("title");

//            string isbn = bookstoreNode.GetChildText("isbn");

//            string price = bookstoreNode.GetChildText("price");

//            string webSite = bookstoreNode.GetChildText("web-site");


//            AddBookstore(author, title, isbn, price, webSite);


//        }
//    }

//    private static void AddBookstore(string author, string title, string isbn, string price, string webSite)
//    {
//        Console.WriteLine("{0} {1} {2} {3} {4}", author, title, isbn, price, webSite);
//    }


//    private static string GetChildText(this XmlNode node, string tagname)
//    {
//        XmlNode childNode = node.SelectSingleNode(tagname);
//        if (childNode == null)
//        {
//            return null;
//        }
//        return childNode.InnerText;
//    }

//}
