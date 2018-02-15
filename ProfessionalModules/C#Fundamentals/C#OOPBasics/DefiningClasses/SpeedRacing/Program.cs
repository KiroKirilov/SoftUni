using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var carData = new Dictionary<string, Car>();
        var amountOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < amountOfCars; i++)
        {
            var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var currentModel = data[0];
            var currentFuelAmount = double.Parse(data[1]);
            var currentFuelConsumption = double.Parse(data[2]);
            var currentCar = new Car(currentModel, currentFuelAmount, currentFuelConsumption);

            if (!carData.ContainsKey(currentModel))
            {
                carData.Add(currentModel,new Car());
            }

            carData[currentModel] = currentCar;
        }

        var input = "";

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var currentModel = data[1];
            var kilometersToDrive = double.Parse(data[2]);
            if (carData.ContainsKey(currentModel))
            {
                carData[currentModel].DriveCar(kilometersToDrive);
            }
        }

        foreach (var car in carData)
        {
            Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.DistanceTravelled}");
        }
    }
}

