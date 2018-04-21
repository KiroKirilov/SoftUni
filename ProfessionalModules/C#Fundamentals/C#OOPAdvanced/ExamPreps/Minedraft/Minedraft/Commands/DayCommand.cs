using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : AbstractCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string energyOutputToday=this.providerController.Produce();
        string oreProducedToday=this.harvesterController.Produce();

        return energyOutputToday + Environment.NewLine + oreProducedToday;
    }
}
