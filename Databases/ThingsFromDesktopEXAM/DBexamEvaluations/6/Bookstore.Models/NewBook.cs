using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class NewBook
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string WebSite { get; set; }

        public string ISBN { get; set; }

        public decimal? Price { get; set; }        

        public ICollection<Author> Authors { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
