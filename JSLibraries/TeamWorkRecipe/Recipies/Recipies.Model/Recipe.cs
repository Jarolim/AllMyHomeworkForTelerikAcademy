using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipies.Model
{
    public class Recipe
    {
        private ICollection<User> fans;
        private ICollection<Ingredient> products;

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

         [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        //[InverseProperty("MyRecepies")]
        public virtual User Creator { get; set; }

        //[InverseProperty("Favorites")]

        public Recipe()
        {
            this.products = new HashSet<Ingredient>();
            this.Fans = new HashSet<User>();
        }

        public virtual ICollection<Ingredient> Products
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

        public virtual ICollection<User> Fans
        {
            get
            {
                return this.fans;
            }
            set
            {
                this.fans = value;
            }
        }
    }
}