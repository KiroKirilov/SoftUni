using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProviderControllerTests
{
    private ProviderController providerController;

    [SetUp]
    public void TestInit()
    {
        var repo = new EnergyRepository();
        this.providerController = new ProviderController(repo);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        var provider1 = new List<string>() { "Solar", "1", "100" };
        var provider2 = new List<string>() { "Solar", "2", "100" };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void BrokenProviderIsDeleted()
    {
        var provider1 = new List<string>() { "Solar", "1", "100" };
        this.providerController.Register(provider1);

        for (int i = 0; i < 16; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    [Test]
    public void ProvidersGetRepaired()
    {
        var provider1 = new List<string>() { "Solar", "1", "100" };
        this.providerController.Register(provider1);

        this.providerController.Repair(100);

        Assert.That(this.providerController.Entities.First().Durability, Is.EqualTo(1600));
    }
}

