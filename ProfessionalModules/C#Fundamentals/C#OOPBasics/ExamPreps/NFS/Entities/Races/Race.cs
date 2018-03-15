using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Race
{
    public int Length { get; private set; }

    public string Route { get; private set; }

    public int PrizePool { get; private set; }

    public List<Car> Participants { get; private set; }

    public abstract int GetPerformance(Car car);

    public bool IsOpen{ get; set; }

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
        this.IsOpen = true;
    }
}

