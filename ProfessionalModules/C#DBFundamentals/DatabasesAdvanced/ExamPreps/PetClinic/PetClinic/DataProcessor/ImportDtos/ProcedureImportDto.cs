using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ImportDtos
{
    [XmlType("Procedure")]
    public class ProcedureImportDto
    {
        [XmlElement("Vet")]
        public string Vet { get; set; }

        [XmlElement("Animal")]
        public string Animal { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }
    }
}
