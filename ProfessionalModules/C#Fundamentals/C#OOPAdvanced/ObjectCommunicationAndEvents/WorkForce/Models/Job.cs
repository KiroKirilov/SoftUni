using System;
using System.Collections.Generic;
using System.Text;
using static Program;

public class Job
{
    public event JobDoneEventHandler JobDone;

    public Job(string name, int workHoursRequired, IEmpoyee employee)
    {
        this.Name = name;
        this.WorkHoursRequired = workHoursRequired;
        this.Employee = employee;
        this.IsDone = false;
    }

    public string Name { get; }
    public int WorkHoursRequired { get; private set; }
    public IEmpoyee Employee { get; }
    public bool IsDone { get; private set; }

    public void Update()
    {
        this.WorkHoursRequired -= Employee.WorkHoursPerWeek;
        if (this.WorkHoursRequired<=0 && !this.IsDone)
        {
            JobDone?.Invoke(this, new JobEventArgs(this));
        }
    }

    public void OnJobDone(object sender, JobEventArgs e)
    {
        Console.WriteLine($"Job {this.Name} done!");
        IsDone = true;
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
    }
}
