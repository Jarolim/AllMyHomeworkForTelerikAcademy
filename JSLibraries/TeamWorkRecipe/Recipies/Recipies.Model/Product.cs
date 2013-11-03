using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Model
{
   public class Product
    {
        public int Id { get; set; }

        [Required]

        public string Title { get; set; }
    }
}
