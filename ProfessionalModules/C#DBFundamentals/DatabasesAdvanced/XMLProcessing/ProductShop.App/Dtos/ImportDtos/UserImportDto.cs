﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos
{
    [XmlType("user")]
    public class UserImportDto
    {
        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("lastName")]
        [MinLength(3)]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

    }
}
