using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehicle
{
    protected virtual double FuelQuantity { get; set; }

    protected double FuelConsumption { get; set; }

    protected double TankCapacity { get; set; }

    protected virtual bool Drive(double distance, bool acOn)
    {
        var fuelRequired = distance * this.FuelConsumption;

        if (fuelRequired <= this.FuelQuantity)
        {
            this.FuelQuantity -= fuelRequired;
            return true;
        }

        return false;
    }

    public void PrintDriveResult(double distance,bool acOn)
    {
        if (this.Drive(distance,acOn))
        {
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public void PrintDriveResult(double distance)
    {
        this.PrintDriveResult(distance, true);
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (liters+this.FuelQuantity>this.TankCapacity)
        {
            //Cannot fit { fuel amount} fuel in the tank
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        this.FuelQuantity += liters;
    }

    protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            fuelQuantity = 0;
        }
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
