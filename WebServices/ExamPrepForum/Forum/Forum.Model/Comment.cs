using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Model
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        //[MinLength(6), MaxLength(150)]
        [Column(TypeName= "ntext")]
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public DateTime CommnetDate { get; set; }
    }
}
