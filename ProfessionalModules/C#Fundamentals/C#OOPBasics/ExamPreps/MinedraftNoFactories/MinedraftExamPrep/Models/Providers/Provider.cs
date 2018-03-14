using System;

public abstract class Provider
{
    public string Id { get; private set; }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value < 1 || value > 10000)
            {
                throw new ArgumentException("EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public Provider(string id, double energyOut)
    {
        this.Id = id;
        this.EnergyOutput = energyOut;
    }
}