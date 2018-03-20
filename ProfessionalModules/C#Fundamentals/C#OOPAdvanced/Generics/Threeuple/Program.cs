using System;


public class Program
{
    static void Main(string[] args)
    {
        var pair1Data = Console.ReadLine().Split();
        var name = $"{pair1Data[0]} {pair1Data[1]}";
        var address = pair1Data[2];
        var town = pair1Data[3];
        var pair2Data = Console.ReadLine().Split();
        var name2 = pair2Data[0];
        var liters = double.Parse(pair2Data[1]);
        var state = pair2Data[2];
        var drunkState = state.ToLower() == "drunk" ? "True" : "False";
        var pair3Data = Console.ReadLine().Split();
        var name3 = pair3Data[0];
        var balance = double.Parse(pair3Data[1]);
        var bank = pair3Data[2];

        var tup1 = new Threeuple<string, string,string>(name, address,town);
        var tup2 = new Threeuple<string, double,string>(name2, liters, drunkState);
        var tup3 = new Threeuple<string, double,string>(name3,balance,bank);

        Console.WriteLine(tup1);
        Console.WriteLine(tup2);
        Console.WriteLine(tup3);
    }
}

