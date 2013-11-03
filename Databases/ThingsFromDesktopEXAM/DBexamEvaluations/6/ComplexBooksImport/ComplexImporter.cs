using Bookstore.Models;
using System.Xml;
using Utility;

namespace ComplexBooksImport
{
    class ComplexImporter
    {
        const string File = @"..\..\complex-books.xml";
        const string SearchString = "/catalog/book";

        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(File);

            var books = xmlDocument.SelectNodes(SearchString);

            //XmlParser.ValidateBooks(books);

            var newBooks = XmlParser.ParseXmlBooks(books, true);

            BookstoreDAO.SimpleAddBooks(newBooks);
        }
    }
}
