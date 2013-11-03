using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebAPI.Models
{
    public class TagModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Posts { get; set; }
    }
}