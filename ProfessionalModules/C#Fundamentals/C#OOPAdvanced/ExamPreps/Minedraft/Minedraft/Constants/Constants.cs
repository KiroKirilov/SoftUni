using System;

public static class Constants
{
    public const string SuccessfullRegistration = "Successfully registered {0}";

    public const string ProvidersRepaired = "Providers are repaired by {0}";

    public const string OreOutputToday = "Produced {0} ore today!";

    public const string EnergyProducedToday = "Produced {0} energy today!";

    public const string DefaultHarvesterMode = "Full";

    public const string ModeChanged = "Mode changed to {0}!";

    public const string CommandNotFound = "{0} does not exist.";

    public const string CommandNotImplementingICommand = "{0} does not implement ICommand.";

    public const string HarvesterBroke = "Harvester with ID {0} broke";

    public const string ProviderBroke = "Provider with ID {0} broke";

    public const string ShutdownMessage = "System Shutdown";

    public const string TotalOreMinedMessage = "Total Mined Plumbus Ore: {0}";

    public const string TotalEnergyProducedMessage = "Total Energy Produced: {0}";

    public const string NoEntityWithThisIdFound = "No entity found with id - {0}";

    public const string DurabilityMessage = "Durability: {0}";

    public const int EntityBreakAmount = 100;

    public const int EntityInitialDurability=1000;
}