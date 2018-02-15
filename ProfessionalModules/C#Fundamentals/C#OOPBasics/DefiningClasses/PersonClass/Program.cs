using System;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var currentName = data[0];
            var currentAge = int.Parse(data[1]);

            var currentPerson = new Person(currentName, currentAge);

            family.AddMember(currentPerson);
        }

        family.PrintOpinionPoll();
    }
}
