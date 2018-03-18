using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Character
    {
        private const double defaultRestHealMultiplier = 0.2;

        private string name;

        private double health;

        private double armor;

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    IsAlive = false;
                    health = 0;
                }
                else
                {
                    health = Math.Min(value, BaseHealth);
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value<0)
                {
                    armor = 0;
                }
                else
                {
                    armor = Math.Min(value, BaseArmor);
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier => defaultRestHealMultiplier;

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                var remainingArmor = this.Armor - hitPoints;
                this.Armor -= hitPoints;

                if (remainingArmor < 0)
                {
                    this.Health += remainingArmor;
                }
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public void GainHeal(double amount)
        {
            this.Health += amount;
        }

        public void TakeDirectDamage(double amount)
        {
            this.Health -= amount;
        }

        public void RestoreArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health += this.BaseHealth * this.RestHealMultiplier;
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
            else
                throw new InvalidOperationException("Must be alive to perform this action!");
        }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Status => this.IsAlive ? "Alive" : "Dead";

        public override string ToString()
        {
            //{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {Status}";
        }
    }
}
