using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.DTOs
{
    public class EmployeeProjectionDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }
        public EmployeeDTO Manager { get; set; }
    }
}
