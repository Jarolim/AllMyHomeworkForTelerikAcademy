using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recipies.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public Category()
        {
            this.Recipes = new HashSet<Recipe>();
        }
    }
}