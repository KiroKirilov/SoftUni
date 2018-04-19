using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Medium : Mission
{
    private const string DefaultName = "Capturing dangerous criminals";
    private const double DefaultEnduranceRequired = 50;
    private const double DefaultWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}

