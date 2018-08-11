using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ImportDtos
{
    [XmlType("Vet")]
    public class VetImportDto
    {
        [MinLength(3), MaxLength(40)]
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required]
        [XmlElement("Profession")]
        public string Profession { get; set; }

        [Required]
        [Range(22, 65)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\+359[0-9]{9}$|^0[0-9]{9}$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
