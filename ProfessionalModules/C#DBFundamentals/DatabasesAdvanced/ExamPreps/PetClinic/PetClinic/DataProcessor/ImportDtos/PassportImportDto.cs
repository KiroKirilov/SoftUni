using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.DataProcessor.ImportDtos
{
    public class PassportImportDto
    {
        [RegularExpression(@"^[A-Za-z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }
                
        [RegularExpression(@"^\+359[0-9]{9}$|^0[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }
        
        [MinLength(3), MaxLength(30)]
        public string OwnerName { get; set; }
        
        public string RegistrationDate { get; set; }
    }
}
