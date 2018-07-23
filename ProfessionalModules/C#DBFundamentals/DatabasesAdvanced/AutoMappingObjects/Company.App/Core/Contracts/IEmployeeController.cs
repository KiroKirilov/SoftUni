using Company.App.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.Core.Contracts
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDTO employeeDTO);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDTO EmployeeInfo(int employeeId);

        EmployeeFullInfoDTO EmployeePersonalInfo(int employeeId);

        EmployeeProjectionDTO[] ListEmployeesOlderThan(int age);
    }
}
