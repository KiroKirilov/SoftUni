using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.ExportDtos
{
    [XmlRoot("users")]
    public class UsersRootExportDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UserWithProductsExportDto[] Users { get; set; }
    }
}
    