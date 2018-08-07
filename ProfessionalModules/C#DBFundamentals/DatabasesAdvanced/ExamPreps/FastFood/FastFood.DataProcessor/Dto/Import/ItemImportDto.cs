using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ItemImportDto
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Category { get; set; }
        
        [Range(0.01, double.PositiveInfinity)]
        public decimal Price { get; set; }
    }
}
