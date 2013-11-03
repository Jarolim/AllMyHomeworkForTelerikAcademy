using Bookstore.Models;
using System.Xml;
using Utility;

namespace SimpleBooksImport
{
    public class SimpleImporter
    {
        const string File = @"..\..\simple-books.xml";

        const string Title = "title";
        const string Author = "author";
        const string ISBN = "isbn";
        const string Website = "web-site";
        const string Price = "price";

        const string SearchString = "/catalog/book";

        public static void Main()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(File);

            var books = xmlDocument.SelectNodes(SearchString);

            // validates required and other fields and throws exception 
            // - stops and not one book of the selection is inported
            XmlParser.ValidateBooks(books);

            var newBooks = XmlParser.ParseXmlBooks(books);

            BookstoreDAO.SimpleAddBooks(newBooks);
        }      
    }        
}
