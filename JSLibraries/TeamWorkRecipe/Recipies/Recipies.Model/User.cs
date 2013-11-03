using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Recipies.Model
{
    public class User
    {
        private ICollection<Recipe> myRecipes;

        private ICollection<Recipe> favorites;

        public int UserId { get; set; }
        
        [RegularExpression(@"^[a-zA-Z''-'''.''''_''\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the name.")]
        [Required(ErrorMessage = "UserName is required.")]
        public string Username { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "AuthCode is required.")]
        public string AuthCode { get; set; }

        [StringLength(50)]
        public string SessionKey { get; set; }

        [Required]
        public Role Role { get; set; }

        //[InverseProperty("Creator")]
        //[InverseProperty("Fans")]
       

        public User()
        {
            this.myRecipes = new HashSet<Recipe>();
            this.favorites = new HashSet<Recipe>();
        }
        public virtual ICollection<Recipe> Favorites
        {
            get
            {
                return this.favorites;
            }
            set
            {
                this.favorites = value;
            }
        }

        public virtual ICollection<Recipe> MyRecipes
        {
            get
            {
                return this.myRecipes;
            }
            set
            {
                this.myRecipes = value;
            }
        }
    }
}
