namespace StichtiteForum.Models
{
    using System;

    public class CommentModel
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public int PostId { get; set; }

        public string AuthorUsername { get; set; }
    }
}