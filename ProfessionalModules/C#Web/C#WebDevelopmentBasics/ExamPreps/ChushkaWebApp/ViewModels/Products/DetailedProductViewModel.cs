using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaWebApp.ViewModels.Products
{
    public class DetailedProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}
