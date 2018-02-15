using System;
using System.Collections.Generic;
using System.Text;


public class Company
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Company(string name, string dep, double salary)
    {
        Name = name;
        Department = dep;
        Salary = salary;
    }
}

