using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    double fuelAmount;
    double fuelConsumption;
    double distanceTravelled;

    public string Model {
        get { return model; }
        set { model = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public double DistanceTravelled
    {
        get { return distanceTravelled; }
        set { distanceTravelled = value; }
    }

    public Car(string modelName, double amount,double consumption)
    {
        model = modelName;
        fuelAmount = amount;
        fuelConsumption = consumption;
        distanceTravelled = 0;
    }

    public Car()
    {

    }

    public void DriveCar(double kilometers)
    {
        var requiredFuel = kilometers * fuelConsumption;

        if (requiredFuel>fuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            fuelAmount -= requiredFuel;
            distanceTravelled += kilometers;
        }
    }
}

