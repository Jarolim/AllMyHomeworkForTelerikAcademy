using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostDate { get; set; }

        public string Text { get; set; }

        public string PostedBy { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}