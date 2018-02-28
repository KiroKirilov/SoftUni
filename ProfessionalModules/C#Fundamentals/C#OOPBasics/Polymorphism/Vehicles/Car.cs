using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    private const double CONSUMPTION_MODIFIER = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm)
        : base(fuelQuantity, fuelConsumptionPerKm + CONSUMPTION_MODIFIER)
    {
    }

}

