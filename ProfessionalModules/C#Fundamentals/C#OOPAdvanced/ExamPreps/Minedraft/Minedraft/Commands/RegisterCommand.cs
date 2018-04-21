using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : AbstractCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }


    public override string Execute()
    {
        string result = "";

        string entityToCreate = this.Arguments[0];
        this.Arguments.RemoveAt(0);

        if (entityToCreate=="Harvester")
        {
            result = this.harvesterController.Register(this.Arguments);
        }
        else
        {
            result = this.providerController.Register(this.Arguments);
        }

        return result;
    }
}
