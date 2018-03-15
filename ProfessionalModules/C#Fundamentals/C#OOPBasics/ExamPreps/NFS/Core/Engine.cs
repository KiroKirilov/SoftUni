using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    public void Run()
    {
        var input = "";
        var cm = new CarManager();

        while ((input=Console.ReadLine())!= "Cops Are Here")
        {
            var args = input.Split(' ');
            var currentCommand = args[0];

            switch (currentCommand)
            {
                case "register":
                    int carId=int.Parse(args[1]);
                    string carType=args[2];
                    string brand=args[3];
                    string model=args[4];
                    int yearOfProduction=int.Parse(args[5]);
                    int horsepower = int.Parse(args[6]);
                    int acceleration = int.Parse(args[7]);
                    int suspension = int.Parse(args[8]);
                    int durability = int.Parse(args[9]);
                    cm.Register(carId,carType,brand,model,yearOfProduction,horsepower,acceleration,suspension,durability);
                    break;

                case "open":
                    int raceId=int.Parse(args[1]);
                    string raceType=args[2];
                    int length=int.Parse(args[3]);
                    string route=args[4];
                    int prizePool= int.Parse(args[5]);
                    cm.Open(raceId, raceType, length, route, prizePool);
                    break;

                case "check":
                    var checkId = int.Parse(args[1]);
                    Console.WriteLine(cm.Check(checkId));
                    break;

                case "start":
                    var startId = int.Parse(args[1]);
                    Console.WriteLine(cm.Start(startId));
                    break;

                case "participate":
                    var raceToJoin = int.Parse(args[2]);
                    var carToJoin = int.Parse(args[1]);
                    cm.Participate(carToJoin, raceToJoin);
                    break;

                case "park":
                    var carToPark = int.Parse(args[1]);
                    cm.Park(carToPark);
                    break;

                case "unpark":
                    var carToUnpark = int.Parse(args[1]);
                    cm.Unpark(carToUnpark);
                    break;

                case "tune":
                    var tuneIndex = int.Parse(args[1]);
                    var addOn = args[2];
                    cm.Tune(tuneIndex, addOn);
                    break;
            }
        }
    }
}

