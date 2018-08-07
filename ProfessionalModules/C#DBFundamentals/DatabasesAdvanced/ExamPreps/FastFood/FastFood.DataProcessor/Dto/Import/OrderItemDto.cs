using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class OrderItemDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
