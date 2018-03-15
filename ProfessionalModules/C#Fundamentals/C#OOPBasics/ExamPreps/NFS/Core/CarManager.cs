using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarManager
{
    private Dictionary<int, Car> cars;

    private Dictionary<int, Race> races;

    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Show":
                cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                break;

            case "Performance":
                cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                break;
        }
    }
    public string Check(int id)
    {
        return cars[id].ToString();
    }
    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                races.Add(id, new CasualRace(length, route, prizePool));
                break;

            case "Drift":
                races.Add(id, new DriftRace(length, route, prizePool));
                break;

            case "Drag":
                races.Add(id, new DragRace(length, route, prizePool));
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!cars[carId].IsParked && races[raceId].IsOpen)
        {
            races[raceId].Participants.Add(cars[carId]);
            cars[carId].Races.Add(raceId);
        }
    }

    public string Start(int id)
    {
        if (races[id].Participants.Count==0)
        {
            return "Cannot start the race with zero participants.";
        }

        var orderedRacers = races[id].Participants.OrderByDescending(c => races[id].GetPerformance(c)).ToList();
        var prizePool = races[id].PrizePool;
        var prizes = new int[3];
        prizes[0] = (prizePool * 50) / 100;
        prizes[1] = (prizePool * 30) / 100;
        prizes[2] = (prizePool * 20) / 100;

        var output = new StringBuilder();
        output.AppendLine($"{races[id].Route} - {races[id].Length}");

        for (int i = 0; i < orderedRacers.Count && i<3; i++)
        {
            output.AppendLine($"{i+1}. {orderedRacers[i].Brand} {orderedRacers[i].Model} {races[id].GetPerformance(orderedRacers[i])}PP - ${prizes[i]}");
        }

        foreach (var car in races[id].Participants)
        {
            car.Races.Remove(id);
        }

        races[id].IsOpen = false;
        return output.ToString().Trim();
    }

    public void Park(int id)
    {
        if (cars[id].Races.Count==0)
        {
            cars[id].IsParked = true;
        }
    }

    public void Unpark(int id)
    {
        if (cars[id].IsParked)
            cars[id].IsParked = false;
    }

    public void Tune(int tuneIndex, string addOn)
    {
        var parkedCars = cars.Values.Where(c => c.IsParked).ToList();

        foreach (var car in parkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}

