namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deserailizedData = JsonConvert.DeserializeObject<DepartmentImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var departments = new List<Department>();

            foreach (var dto in deserailizedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var invalidCells = false;
                var cells = new List<Cell>();
                foreach (var cellDto in dto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        invalidCells = true;
                        break;
                    }

                    var cell = new Cell();
                    cell.HasWindow = cellDto.HasWindow;
                    cell.CellNumber = cellDto.CellNumber;
                    cells.Add(cell);
                }

                if (invalidCells)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department();
                department.Name = dto.Name;
                department.Cells = cells;

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                departments.Add(department);
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserailizedData = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var prisoners = new List<Prisoner>();

            foreach (var dto in deserailizedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var invalidMail = false;
                var mails = new List<Mail>();
                foreach (var mailDto in dto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        invalidMail = true;
                        break;
                    }

                    var mail = new Mail();
                    mail.Description = mailDto.Description;
                    mail.Address = mailDto.Address;
                    mail.Sender = mailDto.Sender;
                    mails.Add(mail);
                }

                if (invalidMail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var prisoner = new Prisoner();
                prisoner.FullName = dto.FullName;
                prisoner.Nickname = dto.Nickname;
                prisoner.IncarcerationDate= DateTime.ParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (dto.ReleaseDate!=null)
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                prisoner.Mails = mails;
                prisoner.Age = dto.Age;
                prisoner.CellId = dto.CellId;
                prisoner.Bail = dto.Bail;
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                prisoners.Add(prisoner);
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerImportDto[]), new XmlRootAttribute("Officers"));
            var deserializedData = (OfficerImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var officers = new List<Officer>();

            foreach (var dto in deserializedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer();
                officer.FullName = dto.Name;
                officer.Salary = dto.Money;
                officer.DepartmentId = dto.DepartmentId;
                var validEnums = Enum.TryParse<Weapon>(dto.Weapon, out Weapon weapon)
                    && Enum.TryParse<Position>(dto.Position, out Position position);

                if (!validEnums)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.Position = Enum.Parse<Position>(dto.Position);
                officer.Weapon = weapon;

                var officerPrisoners = new List<OfficerPrisoner>();

                foreach (var prisDto in dto.Prisoners)
                {
                    var prisonerId=int.Parse(prisDto.Id);

                    var officerPrisoner = new OfficerPrisoner()
                    {
                        PrisonerId = prisonerId,
                        Officer = officer
                    };

                    officerPrisoners.Add(officerPrisoner);

                }

                officer.OfficerPrisoners = officerPrisoners;

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResult, true);
        }
    }
}