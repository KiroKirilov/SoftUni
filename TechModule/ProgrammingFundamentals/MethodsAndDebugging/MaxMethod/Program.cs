using System;

public class Program
{


    public static int GetMax(int a, int b)
    {

        if (a > b) return a;
        else return b;


    }



    public static void Main()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(GetMax(n1, n2), GetMax(n2, n3)));
    }
}