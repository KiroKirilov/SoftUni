using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double defaultBaseHp = 100;
        private const double defaultBaseArmor = 50;
        private const double defaultAbilityPoints = 40;

        public Warrior(string name, Faction faction) 
            : base(name, defaultBaseHp, defaultBaseArmor, defaultAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Equals(character))
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                if (this.Faction==character.Faction)
                {
                    throw new ArgumentException ($"Friendly fire! Both characters are from {this.Faction.ToString()} faction!");
                }

                character.TakeDamage(this.AbilityPoints);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
