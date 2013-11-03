using System;
using System.Collections.Generic;
using System.Xml;
using Bookstore.Data;

static class SimpleBookSearch
{
	static void Main()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../simple-query.xml");
		XmlNode queryNode = xmlDoc.DocumentElement;
		string title = queryNode.GetChildText("title");
		string author = queryNode.GetChildText("author");
		string isbn = queryNode.GetChildText("isbn");

		IList<Book> books = BookstoreDAL.FindBooks(title, author, isbn);

		PrintBooks(books);			
	}

	public static void PrintBooks(IList<Book> books)
	{
		if (books.Count == 0)
		{
			Console.WriteLine("Nothing found");
			return;
		}

		Console.WriteLine("{0} book found: ", books.Count);

		foreach (var book in books)
		{
			if (book.Reviews.Count != 0)
			{
				Console.WriteLine(book.Title + " --> " + book.Reviews.Count + " reviews");
			}
			else
			{
				Console.WriteLine(book.Title + " --> no reviews");
			}
		}
	}
}
