using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    private const double CONSUMPTION_MODIFIER= 1.6;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCap) 
        :base(fuelQuantity, fuelConsumptionPerKm + CONSUMPTION_MODIFIER, tankCap)
    {
    }

    public override void Refuel(double liters)
    {
        var lit = liters * 0.95;
        if (lit <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (lit + this.FuelQuantity > this.TankCapacity)
        {
            //Cannot fit { fuel amount} fuel in the tank
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        this.FuelQuantity += lit;
    }

    protected override double FuelQuantity
    {
        set
        {
            if (value > this.TankCapacity)
            {
                base.FuelQuantity = 0;
            }

            base.FuelQuantity = value;
        }
    }
}

