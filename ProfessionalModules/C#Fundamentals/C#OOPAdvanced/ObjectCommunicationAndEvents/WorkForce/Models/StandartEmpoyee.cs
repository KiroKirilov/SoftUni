using System;
using System.Collections.Generic;
using System.Text;

public class StandartEmpoyee : IEmpoyee
{
    private const int DefaultHoursPerWeek = 40;

    public StandartEmpoyee(string name)
    {
        this.Name = name;
        this.WorkHoursPerWeek = DefaultHoursPerWeek;
    }

    public string Name { get; }

    public int WorkHoursPerWeek { get; }
}
