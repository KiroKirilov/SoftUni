using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.DTOs
{
    public class ManagerDTO
    {
        public ManagerDTO()
        {
            this.Employees = new List<EmployeeDTO>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}
