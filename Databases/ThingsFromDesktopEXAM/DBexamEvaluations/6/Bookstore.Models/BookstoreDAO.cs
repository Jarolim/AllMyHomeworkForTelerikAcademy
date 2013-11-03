using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;

namespace Bookstore.Models
{
    public static class BookstoreDAO
    {
        const string ByPeriod = "by-period";
        const string ByAuthor = "by-author";

        public static void SimpleAddBooks(List<NewBook> books)
        {
            var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead });
            using (transaction)
            {
                var bookstoreDb = new BookstoreDbContext();

                foreach (var book in books)
                {
                    var newBook = new Book
                    {
                        Title = book.Title,                        
                        WebSite = book.WebSite,
                        Price = book.Price,
                        ISBN = book.ISBN,
                        Authors = GetOrCreateAuthors(book.Authors, bookstoreDb),
                        Reviews = ReviewsAuthorsValidate(book.Reviews, bookstoreDb)
                    };

                    bookstoreDb.Books.Add(newBook);
                }

                bookstoreDb.SaveChanges();
                transaction.Complete();
            }

        }

        private static List<Review> ReviewsAuthorsValidate(ICollection<Review> reviews, BookstoreDbContext BookstoreDb)
        {
            if (reviews == null)
            {
                return null;
            }

            foreach (var review in reviews)
            {
                if (review.Author != null && review.Author.Name != null)
                {
                    var author = GetOrCreateAuthors(new List<Author> { review.Author }, BookstoreDb);

                    review.Author = author.First();
                }
            }

            return reviews.ToList();
        }

        private static List<Author> GetOrCreateAuthors(ICollection<Author> authors,
            BookstoreDbContext bookstoreDb)
        {

            if (authors == null || authors.Count == 0)
            {
                return null;
            }

            var authorsInContext = new List<Author>();
            foreach (var author in authors)
            {  
                var addedAuthor = bookstoreDb.Authors
                    .FirstOrDefault(a => a.Name.ToLower() == author.Name.ToLower());

                if (addedAuthor != null)
                {
                    authorsInContext.Add(addedAuthor);
                }
                else
                {
                    var newAuthor = new Author
                    {
                        Name = author.Name,
                    };

                    bookstoreDb.Authors.Add(newAuthor);
                    authorsInContext.Add(newAuthor);
                    bookstoreDb.SaveChanges();
                }
            }

            return authorsInContext;
        }

        public static List<Review> FindReviews(string type, string startDate, string endDate, string author)
        {
            using (var dbContex = new BookstoreDbContext())
            {
                var reviews = dbContex.Reviews.Include("Author").Include("Book").AsQueryable();
                if (startDate != null)
                {
                    var starOfPeriod = DateTime.Parse(startDate);
                    var endOfPeriod = DateTime.Parse(endDate);

                    reviews = reviews.Where(r => r.CreationDate >= starOfPeriod && r.CreationDate <= endOfPeriod);
                }

                if (author != null)
                {
                    reviews = reviews.Where(r => r.Author.Name.ToLower() == author.ToLower());
                }

                reviews = reviews.OrderBy(r => r.CreationDate).ThenBy(r => r.Text).Select(r => new Review
                {
                    CreationDate = r.CreationDate,
                    Text = r.Text,
                    Book = new Book
                    {
                        Authors = r.Book.Authors,
                        Title = r.Book.Title,
                        WebSite = r.Book.WebSite,
                        ISBN = r.Book.ISBN,
                    }
                });                  

                return reviews.ToList();
            }            
        }
    }
}
