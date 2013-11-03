using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Model
{
    public class Laptop
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Laptop()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }
        
        [Key]
        public int Id { get; set; }


        public int ManufacturerId { get; set; }

        
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public double MonitorSize { get; set; }

        [Required]
        public int HardDiskSize { get; set; }

        [Required]
        public int RamMemorySize { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
