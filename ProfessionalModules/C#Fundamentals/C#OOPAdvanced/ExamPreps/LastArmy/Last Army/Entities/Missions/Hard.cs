using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Hard : Mission
{
    private const string DefaultName = "Disposal of terrorists";
    private const double DefaultEnduranceRequired = 80;
    private const double DefaultWearLevelDecrement = 70;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}

