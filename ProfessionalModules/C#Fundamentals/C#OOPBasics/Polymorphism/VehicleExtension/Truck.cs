﻿using System;
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
        base.Refuel(liters*0.95);
    }
}
