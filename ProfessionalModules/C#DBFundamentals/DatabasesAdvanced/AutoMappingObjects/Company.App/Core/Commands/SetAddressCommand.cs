using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Company.App.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetAddressCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            var address = string.Join(" ",args.Skip(1));

            this.employeeController.SetAddress(id, address);

            return string.Format(Constants.UpdatedAddressMessage, id);
        }
    }
}
