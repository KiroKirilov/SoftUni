using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=DESKTOP-SFUMBE8\SQLEXPRESS;" +
                                               @"Database=MiniORM;" +
                                               @"Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Goshkata",
                LastName = "Imported",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
