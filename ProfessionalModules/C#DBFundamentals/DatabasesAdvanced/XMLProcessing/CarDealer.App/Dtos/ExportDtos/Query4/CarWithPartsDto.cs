using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.App.Dtos.ExportDtos.Query4
{
    [XmlType("car")]
    public class CarWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public double TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }
}
