using System;

public class Program
{
    public static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        char start = (char)a;
        char end = (char)b;

        for (char i = start; i <= end; i++)
        {

            Console.Write(i + " ");


        }
    }
}
