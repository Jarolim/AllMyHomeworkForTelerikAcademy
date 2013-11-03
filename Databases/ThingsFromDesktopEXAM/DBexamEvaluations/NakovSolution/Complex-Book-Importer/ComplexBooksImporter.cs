using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

static class ComplexBooksImporter
{
	static void Main()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load("../../complex-books.xml");
		XmlNodeList booksList = xmlDoc.SelectNodes("/catalog/book");
		foreach (XmlNode bookNode in booksList)
		{
			ProcessBookNode(bookNode);
		}
	}

	private static void ProcessBookNode(XmlNode bookNode)
	{
		string title;
		IList<string> authors;
		decimal? price;
		string isbn;
		string url;
		ParseBookNode(bookNode, out title, out authors, out price, out isbn, out url);

		// Parse the book and its reviews and add them to DB in a transaction
		TransactionScope tran = new TransactionScope(TransactionScopeOption.Required,
			new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead });
		using (tran)
		{
			Book book = BookstoreDAL.AddBook(title, authors, price, isbn, url);
			XmlNodeList reviewsList = bookNode.SelectNodes("reviews/review");
			foreach (XmlNode reviewNode in reviewsList)
			{
				ProcessBookReviewNode(reviewNode, book);
			}
			tran.Complete();
		}
	}

	private static void ParseBookNode(XmlNode bookNode, out string title, 
		out IList<string> authors, out decimal? price, out string isbn, out string url)
	{
		title = bookNode.GetChildText("title");
		XmlNodeList authorsList = bookNode.SelectNodes("authors/author");
		authors = new List<string>();
		foreach (XmlNode authorNode in authorsList)
		{
			string authorName = authorNode.InnerText;
			authors.Add(authorName);
		}
		string priceStr = bookNode.GetChildText("price");
		price = null;
		if (priceStr != null)
		{
			price = decimal.Parse(priceStr);
		}
		isbn = bookNode.GetChildText("isbn");
		url = bookNode.GetChildText("web-site");
	}

	private static void ProcessBookReviewNode(XmlNode reviewNode, Book book)
	{		
		var authorAttrib = reviewNode.Attributes["author"];
		string reviewAuthor = null;
		if (authorAttrib != null)
		{
			reviewAuthor = authorAttrib.Value;
		}
		var dateAttrib = reviewNode.Attributes["date"];
		DateTime reviewDate = DateTime.Now;
		if (dateAttrib != null)
		{
			reviewDate = DateTime.ParseExact(
				dateAttrib.Value, Constants.DATE_FORMAT, Constants.DEFAULT_CULTURE);
		}
		string reviewContent = reviewNode.InnerText;

		BookstoreDAL.AddReview(book, reviewAuthor, reviewDate, reviewContent);			
	}
}
