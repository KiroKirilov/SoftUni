using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.energyRepository = energyRepository;
        this.factory = factory;
        this.mode = Constants.DefaultHarvesterMode;
        this.harvesters = new List<IHarvester>();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        //calculate needed energy
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedToday = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            //mine
            foreach (var harvester in this.harvesters)
            {
                minedToday += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.mode == "Energy")
        {
            minedToday = minedToday * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedToday = minedToday * 50 / 100;
        }

        this.OreProduced += minedToday;
        return string.Format(Constants.OreOutputToday, minedToday);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}

