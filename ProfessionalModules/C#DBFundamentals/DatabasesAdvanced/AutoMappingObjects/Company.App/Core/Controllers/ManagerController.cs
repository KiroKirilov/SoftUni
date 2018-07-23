using AutoMapper;
using Company.App.Core.Contracts;
using Company.App.Core.DTOs;
using Company.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.App.Core.Controllers
{
    public class ManagerController : IManagerController
    {
        private readonly CompanyContext context;
        private readonly IMapper mapper;

        public ManagerController(CompanyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ManagerDTO ManagerInfo(int employeeId)
        {
            var manager = this.context.Employees
                .Include(e => e.ManagerEmployees)
                .FirstOrDefault(e => e.Id == employeeId);

            var managerDto = this.mapper.Map<ManagerDTO>(manager);

            if (managerDto == null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            return managerDto;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee==null || manager==null)
            {
                throw new ArgumentException(Constants.InvalidIdMessage);
            }

            employee.Manager = manager;

            this.context.SaveChanges();
        }
    }
}
