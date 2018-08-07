﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrderImportDto
    {
        [XmlElement("Customer")]
        public string Customer { get; set; }

        [XmlElement("Employee")]
        public string Employee { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlArray("Items")]
        public OrderItemDto[] Items { get; set; }
    }
}
