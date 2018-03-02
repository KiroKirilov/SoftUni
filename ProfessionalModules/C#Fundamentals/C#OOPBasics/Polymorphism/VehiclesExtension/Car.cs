using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    private const double CONSUMPTION_MODIFIER = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm,double tankCap)
        : base(fuelQuantity, fuelConsumptionPerKm + CONSUMPTION_MODIFIER,tankCap)
    {
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

