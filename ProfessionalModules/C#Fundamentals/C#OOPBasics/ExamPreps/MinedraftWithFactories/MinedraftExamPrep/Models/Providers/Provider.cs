using System;

public abstract class Provider :Unit
{
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
        :base (id)
    {
        this.EnergyOutput = energyOut;
    }
}