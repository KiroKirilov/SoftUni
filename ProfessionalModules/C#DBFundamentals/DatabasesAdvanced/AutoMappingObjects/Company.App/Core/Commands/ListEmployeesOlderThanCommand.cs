using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public ListEmployeesOlderThanCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            var age = int.Parse(args[0]);
            var employees = this.employeeController.ListEmployeesOlderThan(age);

            var output = new StringBuilder();

            foreach (var em in employees)
            {
                var manager = "";

                if (em.Manager==null)
                {
                    manager = "[no manager]";
                }
                else
                {
                    manager = em.Manager.FirstName + " " + em.Manager.LastName;
                }

                output.AppendLine(string.Format(Constants.ProjectionMessage,em.FirstName,em.LastName,em.Salary,manager));
            }

            return output.ToString().Trim();
        }
    }
}
