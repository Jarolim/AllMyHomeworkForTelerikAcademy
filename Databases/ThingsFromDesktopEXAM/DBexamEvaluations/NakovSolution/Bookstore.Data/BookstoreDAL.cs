using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Data
{
	public class BookstoreDAL
	{
		public static Book AddBook(
			string title, string authorName, decimal? price, string isbn, string url)
		{
			BookstoreEntities context = new BookstoreEntities();
			Book newBook = new Book();
			newBook.Title = title;
            if (authorName != null)
            {
                Author author = CreateOrLoadAuthor(context, authorName);
                newBook.Authors.Add(author);
            }
			newBook.Price = price;
			newBook.ISBN = isbn;
			newBook.Url = url;
			context.Books.Add(newBook);
			context.SaveChanges();

			return newBook;
		}

		private static Author CreateOrLoadAuthor(
			BookstoreEntities context, string authorName)
		{
			Author existingAuthor =
				(from a in context.Authors
				 where a.Name.ToLower() == authorName.ToLower()
				 select a).FirstOrDefault();
			if (existingAuthor != null)
			{
				return existingAuthor;
			}

			Author newAuthor = new Author();
			newAuthor.Name = authorName;
			context.Authors.Add(newAuthor);
			context.SaveChanges();

			return newAuthor;
		}

		public static Book AddBook(string title, IList<string> authors, 
			decimal? price, string isbn, string url)
		{
			BookstoreEntities context = new BookstoreEntities();
			Book newBook = new Book();
			newBook.Title = title;
			foreach (var authorName in authors)
			{
				Author author = CreateOrLoadAuthor(context, authorName);
				newBook.Authors.Add(author);
			}
			newBook.Price = price;
			newBook.ISBN = isbn;
			newBook.Url = url;
			context.Books.Add(newBook);
			context.SaveChanges();

			return newBook;
		}

		public static Review AddReview(Book book, string reviewAuthor, 
			DateTime reviewDate, string reviewContent)
		{
			BookstoreEntities context = new BookstoreEntities();
			Review newReview = new Review();
			newReview.BookId = book.BookId;
			if (reviewAuthor != null)
			{
				Author author = CreateOrLoadAuthor(context, reviewAuthor);
				newReview.Author = author;
			}
			newReview.Date = reviewDate;
			newReview.Content = reviewContent;
			context.Reviews.Add(newReview);
			context.SaveChanges();

			return newReview;
		}

		public static IList<Book> FindBooks(string title, string author, string isbn)
		{
			BookstoreEntities context = new BookstoreEntities();
			var queryBooks = context.Books.Include("Reviews").AsQueryable();
			if (title != null)
			{
				queryBooks = queryBooks.Where(b => b.Title.ToLower() == title.ToLower());
			}
			if (author != null)
			{
				queryBooks = queryBooks.Where(b =>
					b.Authors.Any(a => a.Name.ToLower() == author.ToLower()));
			}
			if (isbn != null)
			{
				queryBooks = queryBooks.Where(b => b.ISBN.ToLower() == isbn.ToLower());
			}
			queryBooks = queryBooks.OrderBy(b => b.Title);

			var books = queryBooks.ToList();
			return books;
		}

		public static IList<Review> FindReviews(DateTime startDate, DateTime endDate)
		{
			BookstoreEntities context = new BookstoreEntities();
			var queryReviews = 
				from review in context.Reviews.Include("Book").Include("Book.Authors")
				where review.Date >= startDate && review.Date <= endDate
				orderby review.Date, review.Content
				select review;
			var reviews = queryReviews.ToList();
			return reviews;
		}

		public static IList<Review> FindReviews(string reviewAuthorName)
		{
			BookstoreEntities context = new BookstoreEntities();
			var queryReviews =
				from review in context.Reviews.Include("Book").Include("Book.Authors")
				where review.Author.Name == reviewAuthorName
				orderby review.Date, review.Content
				select review;
			var reviews = queryReviews.ToList();
			return reviews;
		}
	}
}
