using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentImportDto
    {
        [MinLength(3), MaxLength(25)]
        [Required]
        public string Name { get; set; }

        public CellDto[] Cells { get; set; }

    }
}
