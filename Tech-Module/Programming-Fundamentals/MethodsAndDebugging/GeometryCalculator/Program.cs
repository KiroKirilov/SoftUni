using System;

public class Program
{

    public static double calculator(string fig, double a, double b)
    {
        switch (fig)
        {

            case "rectangle": return a * b;

            case "square": return a * a;

            case "circle": return Math.PI * a * a;

            case "triangle": return (a * b) / 2;

            default: return 0;
        }



    }


    public static void Main()
    {
        string f = Console.ReadLine();
        double s1;
        double s2;
        if (f == "square" || f == "circle")
        {
            s1 = double.Parse(Console.ReadLine());
            s2 = 0;
        }
        else
        {

            s1 = double.Parse(Console.ReadLine());
            s2 = double.Parse(Console.ReadLine());

        }
        double res = calculator(f, s1, s2);

        Console.WriteLine("{0:f2}", res);
    }

}