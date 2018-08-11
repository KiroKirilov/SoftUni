using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ExportDtos
{
    [XmlType("AnimalAid")]
    public class AnimalAidExprotDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}