﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.ExportDtos
{
    [XmlType("category")]
    public class CategoryExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("products-count")]
        public int ProductCount { get; set; }

        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }

        [XmlElement("total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}
