using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public abstract void AffectCharacter(Character character);
    }
}
