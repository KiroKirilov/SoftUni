using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.App.Dtos.ImportDtos
{
    //<part name="Bonnet/hood" price="1001.34" quantity="10" />
    [XmlType("part")]
    public class PartsImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }
}
