using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : AbstractCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        IReadOnlyCollection<IEntity> harvesters = this.harvesterController.Entities;
        IReadOnlyCollection<IEntity> providers = this.providerController.Entities;

        IEnumerable<IEntity> allEntities = harvesters.Concat(providers);

        int idToSearchFor = int.Parse(this.Arguments[0]);

        IEntity entity = allEntities.FirstOrDefault(e => e.ID == idToSearchFor);

        string result = "";

        if (entity==null)
        {
            result = string.Format(Constants.NoEntityWithThisIdFound, idToSearchFor);
        }
        else
        {
            result = entity.ToString();
        }

        return result;
    }
}

