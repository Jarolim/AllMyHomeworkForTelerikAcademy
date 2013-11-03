using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Author
    {
        private List<Book> books;

        public Author()
        {
            this.books = new List<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
            }
        }

    }
}
