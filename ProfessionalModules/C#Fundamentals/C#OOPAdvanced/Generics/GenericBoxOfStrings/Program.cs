using System;


class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            Console.WriteLine(box.ToString());
        }
    }
}

