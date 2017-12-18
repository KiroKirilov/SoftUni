using System;

public class Program
{
    public static void Main()
    {

        int count = 0;

        while (true)
        {
            int i;
            bool isInt = int.TryParse(Console.ReadLine(), out i);

            if (isInt) count++;
            else break;
        }

        Console.WriteLine(count);

    }
}
