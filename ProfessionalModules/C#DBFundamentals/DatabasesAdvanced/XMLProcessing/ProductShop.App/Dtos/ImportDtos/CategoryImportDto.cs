using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("category")]
    public class CategoryImportDto
    {
        [MinLength(3)]
        [MaxLength(15)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
