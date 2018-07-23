using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var employee = this.employeeController.EmployeeInfo(id);

            return string.Format(Constants.EmployeeInfoMessage, id, employee.FirstName, employee.LastName, employee.Salary);
        }
    }
}
