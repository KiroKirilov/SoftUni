using System;

public class Program
{
    public static void Main()
    {
        int a = 5;
        int b = 10;
        int temp;
        Console.WriteLine("Before:");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);

        temp = a;
        a = b;
        b = temp;
        Console.WriteLine("After:");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
    }
}