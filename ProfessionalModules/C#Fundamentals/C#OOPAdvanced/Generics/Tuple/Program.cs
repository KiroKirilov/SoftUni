using System;


public class Program
{
    static void Main(string[] args)
    {
        var pair1Data = Console.ReadLine().Split();
        var name = $"{pair1Data[0]} {pair1Data[1]}";
        var address = pair1Data[2];
        var pair2Data = Console.ReadLine().Split();
        var name2 = pair2Data[0];
        var liters = double.Parse(pair2Data[1]);
        var pair3Data = Console.ReadLine().Split();
        var intParam = int.Parse(pair3Data[0]);
        var doubleParam = double.Parse(pair3Data[1]);

        var tup1 = new Tuple<string, string>(name, address);
        var tup2 = new Tuple<string, double>(name2, liters);
        var tup3 = new Tuple<int, double>(intParam, doubleParam);

        Console.WriteLine(tup1);
        Console.WriteLine(tup2);
        Console.WriteLine(tup3);
    }
}

