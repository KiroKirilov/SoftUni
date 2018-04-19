using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammoType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == ammunitionName);

        IAmmunition ammo = (IAmmunition) Activator.CreateInstance(ammoType);

        return ammo;
    }
}
