using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }
        //•	Categories have an id and name(from 3 to 15 characters)
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
