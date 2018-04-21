using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : AbstractCommand
{
    private IProviderController providerController;
    public RepairCommand(IList<string> args, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double valueToRepair = double.Parse(this.Arguments[0]);
        return this.providerController.Repair(valueToRepair);
    }
}

