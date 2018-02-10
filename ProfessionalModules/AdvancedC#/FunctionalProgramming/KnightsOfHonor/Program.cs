using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> sirify =
                (name) => Console.WriteLine(name);

            foreach (var name in names)
            {
                sirify($"Sir {name}");
            }
        }
    }
}
