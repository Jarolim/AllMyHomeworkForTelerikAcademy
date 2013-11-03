using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }

        public DateTime? CreationDate { get; set; }

    }
}
