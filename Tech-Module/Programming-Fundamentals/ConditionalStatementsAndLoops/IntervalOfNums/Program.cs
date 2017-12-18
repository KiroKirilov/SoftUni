using System;

public class Program
{
    public static void Main()
    {
        var n1 = int.Parse(Console.ReadLine());
        var n2 = int.Parse(Console.ReadLine());

        if (n2 > n1)
        {
            for (var i = n1; i <= n2; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            for (var i = n2; i <= n1; i++) Console.WriteLine(i);
        }
    }
}
