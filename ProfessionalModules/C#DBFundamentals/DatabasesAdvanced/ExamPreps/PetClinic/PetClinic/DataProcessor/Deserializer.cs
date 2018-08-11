namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ImportDtos;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string RecordSuccessMessage = "Record {0} successfully imported.";
        private const string AnimalSuccessMessage = "Record {0} Passport №: {1} successfully imported.";
        private const string ProcedureSuccessMessage = "Record successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var deserailizedData = JsonConvert.DeserializeObject<AnimalAidImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var animalAids = new List<AnimalAid>();

            foreach (var dto in deserailizedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var alreadyExists = context.AnimalAids.Any(aid => aid.Name == dto.Name) ||
                    animalAids.Any(aid => aid.Name == dto.Name);

                if (alreadyExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAid = new AnimalAid()
                {
                    Name = dto.Name,
                    Price = dto.Price
                };

                animalAids.Add(animalAid);
                sb.AppendLine(string.Format(RecordSuccessMessage, dto.Name));
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var deserailizedData = JsonConvert.DeserializeObject<AnimalImportDto[]>(jsonString);

            var sb = new StringBuilder();

            var animals = new List<Animal>();

            var invalidAid = false;

            foreach (var dto in deserailizedData)
            {
                if (!IsValid(dto) || !IsValid(dto.Passport))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var passportExists = context.Passports.Any(p => p.SerialNumber == dto.Passport.SerialNumber) ||
                    animals.Any(a => a.PassportSerialNumber == dto.Passport.SerialNumber);

                if (passportExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animal = new Animal()
                {
                    Name = dto.Name,
                    Passport = new Passport()
                    {
                        OwnerName = dto.Passport.OwnerName,
                        OwnerPhoneNumber = dto.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(dto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                        SerialNumber = dto.Passport.SerialNumber
                    },
                    Age = dto.Age,
                    PassportSerialNumber = dto.Passport.SerialNumber,
                    Type = dto.Type
                };

                animals.Add(animal);
                sb.AppendLine(string.Format(AnimalSuccessMessage, dto.Name, dto.Passport.SerialNumber));
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(VetImportDto[]), new XmlRootAttribute("Vets"));
            var deserializedData = (VetImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var vets = new List<Vet>();

            foreach (var dto in deserializedData)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var alreadyExists = context.Vets.Any(v => v.PhoneNumber == dto.PhoneNumber) ||
                    vets.Any(v => v.PhoneNumber == dto.PhoneNumber);

                if (alreadyExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var vet = new Vet()
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Profession = dto.Profession,
                    PhoneNumber = dto.PhoneNumber
                };

                vets.Add(vet);
                sb.AppendLine(string.Format(RecordSuccessMessage,dto.Name));
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProcedureImportDto[]), new XmlRootAttribute("Procedures"));
            var deserializedData = (ProcedureImportDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var procedures = new List<Procedure>();
            

            foreach (var dto in deserializedData)
            {
                var animalId = context.Animals.FirstOrDefault(a=>a.PassportSerialNumber==dto.Animal)?.Id;
                var vetId = context.Vets.FirstOrDefault(v => v.Name == dto.Vet)?.Id;

                if (animalId==null|| vetId == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var procedure = new Procedure();
                procedure.AnimalId = animalId.Value;
                procedure.VetId = vetId.Value;
                procedure.DateTime = DateTime.ParseExact(dto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                var procedureAnimalAids = new List<ProcedureAnimalAid>();

                var hasInvalidAid = false;

                foreach (var aid in dto.AnimalAids)
                {
                    var animalAidId = context.AnimalAids.FirstOrDefault(a => a.Name == aid.Name)?.Id;

                    if (animalAidId == null)
                    {
                        hasInvalidAid = true;
                        continue;
                    }

                    var alreadyExists = procedureAnimalAids.Any(pa => pa.AnimalAidId == animalAidId.Value);

                    if (alreadyExists)
                    {
                        hasInvalidAid = true;
                        continue;
                    }

                    var procedureAnimalAid = new ProcedureAnimalAid()
                    {
                        AnimalAidId = animalAidId.Value,
                        Procedure = procedure
                    };

                    procedureAnimalAids.Add(procedureAnimalAid);
                }

                if (hasInvalidAid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                procedure.ProcedureAnimalAids = procedureAnimalAids;
                procedures.Add(procedure);

                sb.AppendLine(ProcedureSuccessMessage);
            }

            context.Procedures.AddRange(procedures);
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
