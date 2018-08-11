using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Vet
    {
        public Vet()
        {
            this.Procedures = new List<Procedure>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required]
        public string Profession { get; set; }

        [Required]
        [Range(22,65)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\+359[0-9]{9}$|^0[0-9]{9}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
