using System;
using System.Collections.Generic;
using System.Text;


public class Worker:Human
{
    const int DAYS_WORKING = 5;

    private double weekSalary;

    public double WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (IsWeekSalaryValid(value))
                weekSalary = value;
        }
    }

    private bool IsWeekSalaryValid(double value)
    {
        if (value<=10)
        {
            throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
        }
        return true;
    }

    private double hoursPerDay;

    public double HoursPerDay
    {
        get { return hoursPerDay; }
        private set
        {
            if (AreWorkHoursValid(value))
                hoursPerDay = value;
        }
    }

    private bool AreWorkHoursValid(double value)
    {
        if (value<1 || value>12)
        {
            throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
        }

        return true;
    }

    public Worker(string first,string last, double weekly, double hours)
        :base(first,last)
    {
        WeekSalary = weekly;
        HoursPerDay = hours;
    }
    
    public double GetSalaryPerHour()
    {
        return this.WeekSalary / DAYS_WORKING / this.hoursPerDay;
    }

    public override string ToString()
    {
        var sb = new StringBuilder()
            .AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.HoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.GetSalaryPerHour():f2}");

        return sb.ToString();
    }
}

