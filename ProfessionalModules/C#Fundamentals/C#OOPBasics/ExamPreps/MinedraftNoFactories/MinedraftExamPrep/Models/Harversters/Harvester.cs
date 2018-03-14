using System;
using System.Text;

public abstract class Harvester
{
    public string Id { get; private set; }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        private set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }
            oreOutput = value;
        }
    }

    public Harvester(string id, double oreOut, double energyReq)
    {
        this.Id = id;
        this.OreOutput = oreOut;
        this.EnergyRequirement = energyReq;
    }

}