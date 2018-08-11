namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Json=Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ExportDtos;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(a => new
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.PassportSerialNumber,
                    RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(a=>a.Age)
                .ThenBy(a=>a.SerialNumber)
                .ToArray();

            return JsonConvert.SerializeObject(animals, Json.Formatting.Indented);
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(p=>p.DateTime)
                .ThenBy(p=>p.Animal.PassportSerialNumber)
                .Select(p=>new ProcedureExportDto()
                {
                    DateTime=p.DateTime.ToString("dd-MM-yyyy",CultureInfo.InvariantCulture),
                    OwnerNumber=p.Animal.Passport.OwnerPhoneNumber,
                    Passport=p.Animal.PassportSerialNumber,
                    AnimalAids=p.ProcedureAnimalAids.Select(aid=>new AnimalAidExprotDto()
                    {
                        Name=aid.AnimalAid.Name,
                        Price=aid.AnimalAid.Price
                    }).ToArray(),
                    TotalPrice=Math.Round(p.ProcedureAnimalAids.Sum(aid=>aid.AnimalAid.Price),2)
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProcedureExportDto[]), new XmlRootAttribute("Procedures"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), procedures, xmlNamespaces);

            return sb.ToString();
        }
    }
}
