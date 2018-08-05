using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            this.ProductsBought = new List<Product>();
            this.ProductsSold = new List<Product>();
        }
        //•	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLength(3)]
        [Required]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; }

        public ICollection<Product> ProductsBought { get; set; }
    }
}
