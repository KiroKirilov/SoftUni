using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.ExportDtos
{
    [XmlType("sold-products")]
    public class UserSoldProductsDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public SoldProductWithAttributesDto[] SoldProducts { get; set; }
    }
}
