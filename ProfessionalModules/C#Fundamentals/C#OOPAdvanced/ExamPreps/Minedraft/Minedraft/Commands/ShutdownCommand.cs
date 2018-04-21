using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : AbstractCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) 
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Constants.ShutdownMessage);
        sb.AppendLine(string.Format(Constants.TotalEnergyProducedMessage, this.providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalOreMinedMessage, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}

