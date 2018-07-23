using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController managerController;

        public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var manager = this.managerController.ManagerInfo(id);

            StringBuilder output = new StringBuilder();

            output.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.Employees.Count}");

            foreach (var em in manager.Employees)
            {
                output.AppendLine($"    - {em.FirstName} {em.LastName} - ${em.Salary:f2}");
            }

            return output.ToString().Trim();
        }
    }
}
