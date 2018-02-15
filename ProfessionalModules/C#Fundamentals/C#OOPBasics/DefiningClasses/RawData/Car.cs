using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tire[] Tires { get;set; }

    //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType>
    //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> 
    //<Tire4Pressure> <Tire4Age>” 

    public Car(string model, int engineSpeed, int enginePower,int cargoWeight, string cargoType
        ,double t1Pressure, double t1Age
        ,double t2Pressure, double t2Age
        ,double t3Pressure, double t3Age
        ,double t4Pressure, double t4Age)
    {
        Model = model;
        Engine = new Engine(engineSpeed, enginePower);
        Cargo = new Cargo(cargoWeight, cargoType);
        Tires = new Tire[4];
        Tires[0] = new Tire(t1Age, t1Pressure);
        Tires[1] = new Tire(t2Age, t2Pressure);
        Tires[2] = new Tire(t3Age, t3Pressure);
        Tires[3] = new Tire(t4Age, t4Pressure);
    }
}

