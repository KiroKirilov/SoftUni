public abstract class Ammunition : IAmmunition
{
    private const double WearLevelMultiplier = 100;
    protected Ammunition(double weight)
    {
        this.Weight = weight;
        this.WearLevel = this.Weight * WearLevelMultiplier;
    }
    public string Name => this.GetType().Name;

    public double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}

