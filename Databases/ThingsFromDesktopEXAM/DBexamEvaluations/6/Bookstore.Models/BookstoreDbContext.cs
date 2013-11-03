using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class BookstoreDbContext: DbContext
    {
        public BookstoreDbContext()
            :base("BooksStoreConnection")
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<SearchLogEntry> SearchLog { get; set; }
       
    }
}
