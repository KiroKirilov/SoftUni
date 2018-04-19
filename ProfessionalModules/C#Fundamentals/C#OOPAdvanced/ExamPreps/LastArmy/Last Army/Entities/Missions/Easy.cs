using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Easy : Mission
{
    private const string DefaultName = "Suppression of civil rebellion";
    private const double DefaultEnduranceRequired = 20;
    private const double DefaultWearLevelDecrement = 30;
    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}

