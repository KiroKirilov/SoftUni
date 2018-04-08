using System;
using System.Collections.Generic;
using System.Text;

public class PartTimeEmpoyee : IEmpoyee
{
    private const int DefaultHoursPerWeek= 20;

    public PartTimeEmpoyee(string name)
    {
        this.Name = name;
        this.WorkHoursPerWeek = DefaultHoursPerWeek;
    }

    public string Name { get; }

    public int WorkHoursPerWeek { get; }
}
