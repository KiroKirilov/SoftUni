using System;


class Program
{
    static void Main(string[] args)
    {
        var carData = Console.ReadLine().Split(' ');
        var truckData = Console.ReadLine().Split(' ');

        //Car 15 0.3
        //veh fuelquant fuelcons
        //Truck 100 0.9

        Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
        Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

        var amountOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < amountOfCommands; i++)
        {
            var currentCommand = Console.ReadLine().Split(' ');
            var currentVehicle = currentCommand[1];
            var command = currentCommand[0];
            var param = double.Parse(currentCommand[2]);

            if (currentVehicle == "Car")
            {
                ExecuteAction(car, command,param);
            }
            else if (currentVehicle == "Truck")
            {
                ExecuteAction(truck, command, param);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void ExecuteAction(Vehicle vehicle, string command, double parameter)
    {
        switch (command)
        {
            case "Drive":
                vehicle.PrintDriveResult(parameter);
                break;
            case "Refuel":
                vehicle.Refuel(parameter);
                break;
        }
    }
}

