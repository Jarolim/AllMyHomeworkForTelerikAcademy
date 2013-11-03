using Newtonsoft.Json;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Recipies.Models
{
   public class CategoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonIgnore]
        public static Expression<Func<Category, CategoryModel>> FromCategoryToCategoryModel
        {
            get
            {
                return x => new CategoryModel()
                {
                    Id = x.Id,
                    Name = x.Title,
                };
            }
        }
    }
}
