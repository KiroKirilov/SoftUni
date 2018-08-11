using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class AnimalAid
    {
        public AnimalAid()
        {
            this.AnimalAidProcedures = new List<ProcedureAnimalAid>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01,Double.PositiveInfinity)]
        public decimal Price { get; set; }

        public ICollection<ProcedureAnimalAid> AnimalAidProcedures { get; set; }
    }
}
