using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            switch (name)
            {
                case "HealthPotion":
                    return new HealthPotion();

                case "PoisonPotion":
                    return new PoisonPotion();

                case "ArmorRepairKit":
                    return new ArmorRepairKit();

                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }
        }
    }
}
