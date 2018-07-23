using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = this.employeeController.EmployeePersonalInfo(id);

            return string.Format(Constants.EmployeePersonalInfoMessage, id, employee.FirstName, employee.LastName, employee.Salary, employee.Birthday.Value.ToString("dd-MM-yyyy"), employee.Address);
        }
    }
}
