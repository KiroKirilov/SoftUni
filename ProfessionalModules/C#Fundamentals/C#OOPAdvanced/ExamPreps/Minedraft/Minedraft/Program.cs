public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IHarvesterController harvesterController = new HarvesterController(energyRepository,harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController,providerController);
        Engine engine = new Engine(reader,writer,commandInterpreter);
        engine.Run();
    }
}