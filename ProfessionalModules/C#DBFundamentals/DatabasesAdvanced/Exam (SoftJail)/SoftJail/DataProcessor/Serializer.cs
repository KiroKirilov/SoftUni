namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using Json=Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Xml;
    using System.IO;
    using System.Text;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Any(i => i == p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    }).OrderBy(o => o.OfficerName).ToArray(),

                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(prisoners, Json.Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .Where(p => names.Any(n => n == p.FullName))
                .Select(p => new PrisonerExportDto()
                {
                    Name = p.FullName,
                    Id = p.Id,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Messages = p.Mails.Select(m => new MessageExportDto()
                    {
                        Description = m.Description
                    }).ToArray()
                })
                .OrderBy(p=>p.Name)
                .ThenBy(p=>p.Id)
                .ToArray();

            foreach (var p in prisoners)
            {
                foreach (var m in p.Messages)
                {
                    var charArray = m.Description.ToCharArray();
                    Array.Reverse(charArray);
                    m.Description = new string(charArray);
                }
            }

            var serializer = new XmlSerializer(typeof(PrisonerExportDto[]), new XmlRootAttribute("Prisoners"));
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();
            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString();
        }
    }
}