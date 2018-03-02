using System;
using System.Collections.Generic;
using System.Text;


public class Bus : Vehicle
{
    private const double CONSUMPTION_MODIFIER = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCap) 
        :base(fuelQuantity, fuelConsumption, tankCap)
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

    protected override bool Drive(double distance, bool isAcOn)
    {
        double requiredFuel = 0;

        if (isAcOn)
        {
            requiredFuel = distance * (this.FuelConsumption + CONSUMPTION_MODIFIER);
        }
        else
        {
            requiredFuel = distance * this.FuelConsumption;
        }

        if (requiredFuel <= this.FuelQuantity)
        {
            this.FuelQuantity -= requiredFuel;
            return true;
        }

        return false;
    }
}

