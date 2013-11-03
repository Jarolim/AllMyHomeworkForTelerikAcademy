using System.ComponentModel.DataAnnotations;

namespace Recipies.Model
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        public Measurement Mesaurement { get; set; }

        public int Quantity { get; set; }

         [Required]
        public virtual Recipe Recipe { get; set; }
    }
}