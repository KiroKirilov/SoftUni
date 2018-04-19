using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmo(string ammoName, int quantity);

    bool TryEquipSoldier(ISoldier soldier);
}

