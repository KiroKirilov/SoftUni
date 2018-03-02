using System;


class Program
{
    static void Main(string[] args)
    {
        var carData = Console.ReadLine().Split(' ');
        var truckData = Console.ReadLine().Split(' ');
        var busData = Console.ReadLine().Split(' ');

        //Car 15 0.3 123
        //veh fuelquant fuelcons tankcap
        //Truck 100 0.9 123

        Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
        Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
        Vehicle bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

        var amountOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < amountOfCommands; i++)
        {
            try
            {

                var currentCommand = Console.ReadLine().Split(' ');
                var currentVehicle = currentCommand[1];
                var command = currentCommand[0];
                var param = double.Parse(currentCommand[2]);

                if (currentVehicle == "Car")
                {
                    ExecuteAction(car, command, param);
                }
                else if (currentVehicle == "Truck")
                {
                    ExecuteAction(truck, command, param);
                }
                else if (currentVehicle == "Bus")
                {
                    ExecuteAction(bus, command, param);
                }
            }
            catch (Exception argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
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
            case "DriveEmpty":
                vehicle.PrintDriveResult(parameter, false);
                break;
        }
    }
}

