using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.App.Core.Contracts;
using Company.App.Core.DTOs;
using Company.Data;
using Company.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.App.Core.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        private readonly CompanyContext context;
        private readonly IMapper mapper;

        public EmployeeController(CompanyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = this.mapper.Map<Employee>(employeeDTO);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public EmployeeDTO EmployeeInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeeDto = this.mapper.Map<EmployeeDTO>(employee);

            if (employeeDto == null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            return employeeDto;
        }

        public EmployeeFullInfoDTO EmployeePersonalInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeeFullInfoDto = mapper.Map<EmployeeFullInfoDTO>(employee);

            if (employeeFullInfoDto == null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            return employeeFullInfoDto;
        }

        public EmployeeProjectionDTO[] ListEmployeesOlderThan(int age)
        {
            var employees = this.context.Employees
                .Include(e=>e.Manager)
                .Where(e => DateTime.Now.Year - e.Birthday.Value.Year > age)
                .ProjectTo<EmployeeProjectionDTO>()
                .OrderByDescending(e=>e.Salary)
                .ToArray();

            return employees;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee==null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            employee.Address = address;

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            employee.Birthday = date;

            this.context.SaveChanges();
        }
    }
}
