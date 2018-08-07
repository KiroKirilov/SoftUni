using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        public Item()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [Range(0.01,double.PositiveInfinity)]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}