using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookstoreDAL
    {
        public static void AddBookstore(string author, string title, long? isbn, decimal? price, string webSite)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book newBook = new Book();
            newBook.Author = CreateOrLoadAuthor(context, author);
            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Price = price;
            newBook.WebSite = webSite;

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        public static void AddBookstoreComplex(string author, string title, long? isbn, decimal? price, string webSite, int reviewId)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book newBook = new Book();
            newBook.Author = CreateOrLoadAuthor(context, author);
            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Price = price;
            newBook.WebSite = webSite;
            //newBook.Reviews = CreateOrLoadReview(context, reviewId);

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        private static Author CreateOrLoadAuthor(BookstoreEntities context, string author)
        {
            Author existingAuthor =
                (from a in context.Authors
                 where a.AuthorName == author
                 select a).FirstOrDefault();

            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            Author newAuthor = new Author();
            newAuthor.AuthorName = author;
            context.Authors.Add(newAuthor);

            return newAuthor;
        }

        private static Review CreateOrLoadReview(BookstoreEntities context, int reviewId)
        {
            Review existingReview =
                (from r in context.Reviews
                 where r.ReviewId == reviewId
                 select r).FirstOrDefault();

            if (existingReview != null)
            {
                return existingReview;
            }

            Review newReview = new Review();
            newReview.ReviewId = reviewId;
            context.Reviews.Add(newReview);

            return newReview;
        }

        public static IList<Book> FindBooksByAuthor(string author)
        {
            BookstoreEntities context = new BookstoreEntities();
            var bookstoreQuery =
                from b in context.Books
                select b;

            if (author != null)
            {
                bookstoreQuery =
                    from b in context.Books
                    where b.Author.AuthorName == author
                    select b;
            }

            bookstoreQuery = bookstoreQuery.OrderBy(b => b.Title);

            return bookstoreQuery.ToList();
        }
    }
}

