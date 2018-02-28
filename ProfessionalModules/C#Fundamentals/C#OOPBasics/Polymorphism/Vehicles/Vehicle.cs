using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehicle
{
    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    private bool Drive(double distance)
    {
        var fuelRequired = distance * this.FuelConsumption;

        if (fuelRequired <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelRequired;
            return true;
        }

        return false;
    }

    public void PrintDriveResult(double distance)
    {
        if (this.Drive(distance))
        {
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }

    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelConsumption = fuelConsumption;
        this.FuelQuantity = fuelQuantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
