using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double defaultBaseHp = 50;
        private const double defaultBaseArmor = 25;
        private const double defaultAbilityPoints = 40;

        public Cleric(string name, Faction faction) :
            base(name, defaultBaseHp, defaultBaseArmor, defaultAbilityPoints, new Backpack(), faction)
        {

        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Faction!=character.Faction)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }

                character.GainHeal(this.AbilityPoints);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public override double RestHealMultiplier => 0.5;
    }
}
