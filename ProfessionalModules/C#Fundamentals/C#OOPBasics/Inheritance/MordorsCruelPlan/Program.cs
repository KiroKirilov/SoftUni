using System;


class Program
{
    static void Main(string[] args)
    {
        var foods = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var gandalf = new Gandalf();

        foreach (var food in foods)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf.HappinessPoints);
        Console.WriteLine(gandalf.GetMood());
    }
}

