using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SearchLogEntry
    {
        public int Id { get; set; }
                
        public DateTime Date { get; set; }

        public string QueryXml { get; set; }
    }
}
