using System;


class Program
{
    static void Main(string[] args)
    {
        var studentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var workerInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var studentFirstName = studentInfo[0];
        var studentLastName = studentInfo[1];
        var facNum = studentInfo[2];

        var workerFirstName = workerInfo[0];
        var workerLastName = workerInfo[1];
        var weekSalary = double.Parse(workerInfo[2]);
        var hoursPerDay = double.Parse(workerInfo[3]);

        try
        {
            var student = new Student(studentFirstName, studentLastName, facNum);
            var worker = new Worker(workerFirstName, workerLastName, weekSalary, hoursPerDay);
            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}

