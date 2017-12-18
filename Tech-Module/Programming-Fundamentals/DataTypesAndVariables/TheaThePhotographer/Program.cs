using System;

public class Program
{
    public static void Main()
    {
        long amount = long.Parse(Console.ReadLine());
        long filterTime = long.Parse(Console.ReadLine());
        double filterFactor = double.Parse(Console.ReadLine());
        long uploadTime = long.Parse(Console.ReadLine());
        double filterPercent = filterFactor / 100;

        double filteredPics = Math.Ceiling(amount * filterPercent);
        long totalTime = amount * filterTime;
        totalTime += (long)filteredPics * uploadTime;

        TimeSpan ts = TimeSpan.FromSeconds(totalTime);
        Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
    }
}