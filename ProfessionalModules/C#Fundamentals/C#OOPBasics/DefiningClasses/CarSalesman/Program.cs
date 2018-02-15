using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var amountOfEngines = int.Parse(Console.ReadLine());
        var engines = new Engine[amountOfEngines];

        for (int i = 0; i < amountOfEngines; i++)
        {
            var data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var engModel = data[0];
            var engPower = data[1];
            Engine currentEngine;

            if (data.Length==4)
            {
                var displacement = data[2];
                var eff = data[3];
                currentEngine = new Engine(engModel, eff, engPower, displacement);
                engines[i] = currentEngine;
            }
            else
            {
                if (data.Length == 2)
                {
                    currentEngine = new Engine(engModel, "n/a", engPower, "n/a");
                    engines[i] = currentEngine;
                }
                else
                {
                    double disp = 0;

                    if (double.TryParse(data[2], out disp))
                    {
                        currentEngine = new Engine(engModel, "n/a", engPower, disp.ToString());
                        engines[i] = currentEngine;
                    }
                    else
                    {
                        currentEngine = new Engine(engModel, data[2], engPower, "n/a");
                        engines[i] = currentEngine;
                    }
                }
            }

        }

        var amountOfCars = int.Parse(Console.ReadLine());
        var cars = new Car[amountOfCars];

        for (int i = 0; i < amountOfCars; i++)
        {
            var data = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var carModel = data[0];
            var engModel = data[1];
            var engine = engines.First(e => e.Model == engModel);
            Car currentCar;

            if (data.Length==4)
            {
                var weight = data[2];
                var color = data[3];
                currentCar = new Car(carModel, weight, color, engine);
                cars[i] = currentCar;
            }
            else
            {
                if (data.Length == 2)
                {
                    currentCar = new Car(carModel, "n/a", "n/a", engine);
                    cars[i] = currentCar;
                }
                else
                {
                    double weight = 0;

                    if (double.TryParse(data[2], out weight))
                    {
                        currentCar = new Car(carModel, weight.ToString(), "n/a", engine);
                        cars[i] = currentCar;
                    }
                    else
                    {
                        currentCar = new Car(carModel, "n/a", data[2], engine);
                        cars[i] = currentCar;
                    }
                }
            }
        }
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

