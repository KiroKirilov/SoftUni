using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Globalization;
using System.Linq;

namespace P02_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmployeesFullInformation(); //3. Employees Full Information
            //EmployeesWithSalaryOver50000(); //4. Employees with Salary Over 50 000
            //EmployeesFromResearchAndDevelopment(); //5. Employees from Research and Development
            //AddingANewAddressAndUpdatingEmployee(); //6.Adding a New Address and Updating Employee
            //EmployeesAndProjects(); //7. Employees and Projects
            //AddressesByTown(); //8. Addresses by Town
            //Employee147(); //9. Employee 147
            //DepartmentsWithMoreThan5Employees(); //10. Departments with More Than 5 Employees
            //FindLatest10Projects(); //11. Find Latest 10 Projects
            //IncreaseSalaries(); //12. Increase Salaries
            //FindEmployeesByFirstNameStartingWithSa(); //13. Find Employees by First Name Starting With "Sa"
            //DeleteProjectById(); //14. Delete Project by Id
            //RemoveTowns("Sofia"); // 15.Remove Towns
        }

        private static void RemoveTowns(params string[] names)
        {
            using (var context = new SoftUniContext())
            {
                foreach (var name in names)
                {
                    var town = context.Towns
                       .FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                    if (town == null)
                    {
                        Console.WriteLine($"There is not town with name: {name}");
                        continue;
                    }

                    context.Employees
                        .Where(e => e.Address.Town.TownId == town.TownId)
                        .ToList()
                        .ForEach(e => e.Address = null);

                    var addresses = context.Addresses
                        .Where(a => a.TownId == town.TownId)
                        .ToArray();

                    var addressesCount = addresses.Length;

                    context.Addresses.RemoveRange(addresses);
                    context.Towns.Remove(town);
                    context.SaveChanges();

                    string addressPluralisation = addressesCount == 1
                        ? "address"
                        : "addresses";

                    Console.WriteLine($"{addressesCount} {addressPluralisation} in {name} was deleted");
                }
            }
        }

        private static void DeleteProjectById()
        {
            using (var context = new SoftUniContext())
            {
                var project = context.Projects.Find(2);

                context.EmployeesProjects.RemoveRange(context.EmployeesProjects
                                                            .Where(ep => ep.ProjectId == 2));
                context.Projects.Remove(project);
                context.SaveChanges();

                Console.WriteLine(string.Join(Environment.NewLine, context.Projects
                    .OrderBy(p => p.ProjectId)
                    .Take(10)
                    .Select(p => p.Name)));
            }
        }

        private static void FindEmployeesByFirstNameStartingWithSa()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                    .ToList();

                employees.ForEach(e => Console.WriteLine(e));
            }
        }

        private static void IncreaseSalaries()
        {
            var departmentsForIncrease = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => departmentsForIncrease
                        .Any(d => d.Equals(e.Department.Name, StringComparison.OrdinalIgnoreCase)))
                    .Distinct()
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                foreach (var e in employees)
                {
                    e.Salary *= 1.12m;
                    Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
                }

                context.SaveChanges();
            }
        }

        private static void FindLatest10Projects()
        {
            using (var context = new SoftUniContext())
            {
                var projects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name);

                foreach (var project in projects)
                {
                    Console.WriteLine(project.Name);
                    Console.WriteLine(project.Description);
                    Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                }
            }
        }

        private static void DepartmentsWithMoreThan5Employees()
        {
            using (var context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        Information = $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}",
                        EmployeesInfo = d.Employees
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .Select(e => new
                            {
                                Information = $"{e.FirstName} {e.LastName} - {e.JobTitle}"
                            })
                    });

                foreach (var department in departments)
                {
                    Console.WriteLine(department.Information);

                    foreach (var employee in department.EmployeesInfo)
                    {
                        Console.WriteLine(employee.Information);
                    }

                    Console.WriteLine("----------");
                }
            }
        }

        private static void Employee147()
        {
            using (var context = new SoftUniContext())
            {
                var employeeInfo = context.Employees
                    .Select(e => new
                    {
                        Id = e.EmployeeId,
                        Information = $"{e.FirstName} {e.LastName} - {e.JobTitle}",
                        Projects = e.EmployeesProjects
                            .Select(ep => new
                            {
                                ep.Project.Name
                            })
                            .OrderBy(p => p.Name)
                    })
                    .FirstOrDefault(e => e.Id == 147);

                if (employeeInfo != null)
                {
                    Console.WriteLine(employeeInfo.Information);

                    foreach (var prj in employeeInfo.Projects)
                    {
                        Console.WriteLine(prj.Name);
                    }
                }
            }
        }

        private static void AddressesByTown()
        {
            using (var context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        AddressInfo = $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"
                    })
                    .ToList();

                foreach (var a in addresses)
                {
                    Console.WriteLine(a.AddressInfo);
                }
            }
        }

        private static void EmployeesAndProjects()
        {
            using (var context = new SoftUniContext())
            {
                var employeesWithProjects = context.Employees
                    .Where(e => e.EmployeesProjects
                        .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new
                    {
                        EmployeeName = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects
                            .Select(ep => new
                            {
                                ep.Project.Name,
                                ep.Project.StartDate,
                                ep.Project.EndDate
                            })
                    });

                foreach (var employee in employeesWithProjects)
                {
                    Console.WriteLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");

                    foreach (var project in employee.Projects)
                    {
                        var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        var endDate = project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished";
                        Console.WriteLine($"--{project.Name} - {startDate} - {endDate}");
                    }
                }
            }
        }

        private static void AddingANewAddressAndUpdatingEmployee()
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address();
                address.AddressText = "Vitoshka 15";
                address.TownId = 4;

                var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                employee.Address = address;

                var addresses = context.Employees
                    .Include(e => e.Address)
                    .OrderByDescending(e => e.AddressId)
                    .Select(e => e.Address.AddressText)
                    .Take(10)
                    .ToList();

                foreach (var a in addresses)
                {
                    Console.WriteLine(a);
                }

                context.SaveChanges();
            }
        }

        private static void EmployeesFromResearchAndDevelopment()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Include(e => e.Department)
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
                }
            }
        }

        private static void EmployeesWithSalaryOver50000()
        {
            using (var context = new SoftUniContext())
            {
                var employeeNames = context.Employees
                    .Where(e => e.Salary > 50000)
                    .Select(e => e.FirstName)
                    .OrderBy(e => e);

                foreach (var name in employeeNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static void EmployeesFullInformation()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .OrderBy(e => e.EmployeeId)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
                }
            }
        }
    }
}
