using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> weaponQuantities;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.weaponQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmo(string ammoName, int quantity)
    {
        if (this.weaponQuantities.ContainsKey(ammoName))
        {
            this.weaponQuantities[ammoName] += quantity;
        }
        else
        {
            this.weaponQuantities.Add(ammoName, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        List<string> wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w=>w.Key).ToList();

        bool soldierSuccessfullyEquiped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if (this.weaponQuantities.ContainsKey(weapon) &&
                this.weaponQuantities[weapon]>0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.weaponQuantities[weapon]--;
            }
            else
            {
                soldierSuccessfullyEquiped = false;
            }
        }

        return soldierSuccessfullyEquiped;
    }
}

