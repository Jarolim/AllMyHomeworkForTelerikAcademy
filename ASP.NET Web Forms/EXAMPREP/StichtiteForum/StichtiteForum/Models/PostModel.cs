using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StichtiteForum.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public System.DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public string AuthorUsername { get; set; }
    }
}