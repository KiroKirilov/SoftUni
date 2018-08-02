using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.ExportDtos
{
    [XmlType("user")]
    public class UserExportDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
