﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("product")]
    public class ProductImportDto
    {
        [XmlElement("name")]
        [MinLength(3)]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
