using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var cars=new Car[n];

        for (int i = 0; i < n; i++)
        {
            var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var model = data[0];
            var engSpd = int.Parse(data[1]);
            var engPwr = int.Parse(data[2]);
            var crgWeight = int.Parse(data[3]);
            var crgType = data[4];
            var t1Pressure = double.Parse(data[5]);
            var t1Age = double.Parse(data[6]);
            var t2Pressure = double.Parse(data[7]);
            var t2Age = double.Parse(data[8]);
            var t3Pressure = double.Parse(data[9]);
            var t3Age = double.Parse(data[10]);
            var t4Pressure = double.Parse(data[11]);
            var t4Age = double.Parse(data[12]);

            var currentCar = new Car(model,engSpd,engPwr,crgWeight,crgType,
                t1Pressure,t1Age,t2Pressure,t2Age,t3Pressure,t3Age,t4Pressure,t4Age);

            cars[i] = currentCar;
        }

        var cargoTypeToSearch = Console.ReadLine();

        if (cargoTypeToSearch=="fragile")
        {
            foreach (var car in cars.Where(c=>c.Cargo.Type=="fragile"
                                            && (c.Tires[0].Pressure<1 ||
                                                c.Tires[1].Pressure < 1 ||
                                                c.Tires[2].Pressure < 1 ||
                                                c.Tires[3].Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }

        if (cargoTypeToSearch== "flamable")
        {
            foreach (var car in cars.Where(c=>c.Cargo.Type== "flamable" && c.Engine.Power>250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

