﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Employee
    {
        public Employee()
        {
            this.ManagerEmployees = new List<Employee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerEmployees { get; set; }
    }
}
