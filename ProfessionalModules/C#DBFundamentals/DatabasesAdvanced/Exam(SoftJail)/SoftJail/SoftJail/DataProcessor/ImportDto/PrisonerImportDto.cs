using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDto
    {
        [MinLength(3), MaxLength(20)]
        [Required]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The \b[A-Z][A-Za-z]+\b$")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(0, Double.PositiveInfinity)]
        public decimal? Bail { get; set; }

        [Required]
        public int CellId { get; set; }

        public MailDto[] Mails { get; set; }
    }
}
