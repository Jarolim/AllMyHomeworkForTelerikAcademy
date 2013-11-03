using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        private List<Author> authors;

        private List<Review> reviews;

        public Book()
        {
            this.authors = new List<Author>();
            this.reviews = new List<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string WebSite { get; set; }
        public string ISBN { get; set; }
        public decimal? Price { get; set; }

        
        public virtual List<Author> Authors 
        {
            get
            {
                return this.authors;
            }
            set
            {
                this.authors = value;
            }
        }

        public virtual List<Review> Reviews
        {
            get
            {
                return this.reviews;
            }
            set
            {
                this.reviews = value;
            }
        }
    }
}
