using System;

public class Provider : IProvider
{
    private double durability;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.durability = Constants.EntityInitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }
    
    public double Durability
    {
        get { return this.durability; }
        protected set
        {
            if (value<0)
            {
                throw new ArgumentException(string.Format(Constants.ProviderBroke, this.ID));
            }
            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= Constants.EntityBreakAmount;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        string providerName = this.GetType().Name;
        string durabilityMessage = string.Format(Constants.DurabilityMessage, this.durability);
        return providerName + Environment.NewLine + durabilityMessage;
    }
}