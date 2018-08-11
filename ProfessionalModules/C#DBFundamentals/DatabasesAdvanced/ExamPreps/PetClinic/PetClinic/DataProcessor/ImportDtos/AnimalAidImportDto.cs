using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.DataProcessor.ImportDtos
{
    public class AnimalAidImportDto
    {
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Range(0.01, Double.PositiveInfinity)]
        public decimal Price { get; set; }

    }
}
