using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public delegate void JobDoneEventHandler(object sender, JobEventArgs e);

    static void Main(string[] args)
    {
        var jobs = new CustomJobCollection();
        var employees = new List<IEmpoyee>();

        var input = "";

        while ((input = Console.ReadLine()) != "End") 
        {
            var cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var currentCommand = cmdArgs[0];

            switch (currentCommand)
            {
                case "Job"://Job <nameOfJob> <hoursOfWorkRequired> <employeeName>
                    var nameOfJob = cmdArgs[1];
                    var hoursRequired = int.Parse(cmdArgs[2]);
                    var employeeName = cmdArgs[3];
                    var employee = employees.FirstOrDefault(e => e.Name == employeeName);
                    var job = new Job(nameOfJob, hoursRequired, employee);
                    job.JobDone += job.OnJobDone;
                    jobs.Add(job);
                    break;

                case "Status"://Print all jobs' ToString()
                    var jobsToPrint = jobs.Where(j => j.IsDone == false);
                    var output = string.Join(Environment.NewLine, jobsToPrint);
                    Console.WriteLine(output);
                    break;

                case "StandardEmployee"://StandardEmployee <name>” 
                    var standartEmpoyeeName = cmdArgs[1];
                    var standartEmpoyee = new StandartEmpoyee(standartEmpoyeeName);
                    employees.Add(standartEmpoyee);
                    break;

                case "PartTimeEmployee"://PartTimeEmployee <name>” 
                    var partTimeEmpoyeeName = cmdArgs[1];
                    var partTimeEmpoyee = new PartTimeEmpoyee(partTimeEmpoyeeName);
                    employees.Add(partTimeEmpoyee);
                    break;

                case "Pass"://Pass Week - call all Update methods.
                    foreach (var activeJob in jobs)
                    {
                        activeJob.Update();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}

