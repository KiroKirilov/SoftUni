using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Garage
{
    public Dictionary<int,Car> ParkedCars { get; private set; }

    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public void ParkCar(int id, Car car)
    {
        this.ParkedCars.Add(id, car);
    }
}

