using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController managerController;

        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            this.managerController.SetManager(employeeId, managerId);

            return string.Format(Constants.ManagerUpdatedMessage, employeeId, managerId);
        }
    }
}
