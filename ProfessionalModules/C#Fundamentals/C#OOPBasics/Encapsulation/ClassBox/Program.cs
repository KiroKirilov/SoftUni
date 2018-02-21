using System;



class Program
{
    static void Main(string[] args)
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        { 
            var box = new Box(width, height, length);
            var surfaceArea = box.GetSurfaceArea();
            var lateralSurfaceArea = box.GetLateralSurfaceArea();
            var volume = box.GetVolume();
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }     
    }
}

