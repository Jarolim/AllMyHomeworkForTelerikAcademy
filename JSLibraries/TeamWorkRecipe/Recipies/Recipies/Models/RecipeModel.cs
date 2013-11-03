using Newtonsoft.Json;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Recipies.Models
{
    public class RecipeModel
    {
        [JsonIgnore]
        public static Expression<Func<Recipe, RecipeModel>> FromRecipeToRecipeModel
        {
            get
            {
                return recipe => new RecipeModel()
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    PublishDate = recipe.PublishDate,
                    CreatorUser = recipe.Creator.Username,
                    Rating = recipe.Fans.Count,
                    CategoryName = recipe.Category.Title
                };
            }
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("creator")]
        public string CreatorUser { get; set; }

        [JsonProperty("publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("likes")]
        public int Rating { get; set; }

    }
}