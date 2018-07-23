using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Company.App.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetBirthdayCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);
            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.employeeController.SetBirthday(id, date);

            return string.Format(Constants.UpdatedBirthdayMessage, id);
        }
    }
}
