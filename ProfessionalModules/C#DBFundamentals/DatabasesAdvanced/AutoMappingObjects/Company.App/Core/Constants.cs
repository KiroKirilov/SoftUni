using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core
{
    public static class Constants
    {
        public const string InvalidIdMessage = "Invalid Id Proviced!";

        public const string InvalidCommandMessage = "Invalid command!";

        public const string EmployeeAddedMessage = "Employee {0} {1} added successfully!";

        public const string UpdatedBirthdayMessage = "Updated birthday for employee with id: {0}";

        public const string UpdatedAddressMessage = "Updated address for employee with id: {0}";

        public const string EmployeeInfoMessage = "ID: {0} - {1} {2} -  ${3:f2}";

        public const string EmployeePersonalInfoMessage = "ID: {0} - {1} {2} - ${3:f2}\r\nBirthday: {4}\r\nAddress: {5}";

        public const string ManagerUpdatedMessage = "Manager for employee with Id: {0}, set to: {1}";

        public const string ProjectionMessage = "{0} {1} - ${2:f2} - Manager: {3}";
    }
}
