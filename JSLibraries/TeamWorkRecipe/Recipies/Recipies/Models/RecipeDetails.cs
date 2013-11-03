using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Recipies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Recipies.Models
{
    public class RecipeDetails : RecipeModel
    {
        private IEnumerable<ProductDetails> products;

        [JsonProperty("content")]
        public string Content { get; set; }

        public RecipeDetails()
        {
            this.products = new HashSet<ProductDetails>();
        }

        private static string GetMeasurementAsString(Measurement mesaurement)
        {
            return Enum.GetName(mesaurement.GetType(), mesaurement);

        }

        [JsonProperty("products")]
        public IEnumerable<ProductDetails> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        [JsonIgnore]
        public static Expression<Func<Recipe, RecipeDetails>> FromRecipeToRecipeDetails
        {
            get
            {
                return x => new RecipeDetails()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryName = x.Category.Title,
                    Content = x.Content,
                    PublishDate = x.PublishDate,
                    CreatorUser = x.Creator.Username,
                    Rating = x.Fans.Count,
                    Products = x.Products.Select(
                    p => new ProductDetails() { Name = p.Product.Title, Quantity = p.Quantity, M = p.Mesaurement}).Distinct()
                };
            }
        }

    }

    public class ProductDetails
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        [JsonProperty("mesaurementString")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Measurement M { get; set; }

        public string Measurement { get; set; }
    }
}