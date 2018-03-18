using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        //Capacity – an integer number.Default value: 100
        //Load – Calculated property.The sum of the weights of the items in the bag.
        //Items – Read-only collection of type Item

        private List<Item> items;

        public IReadOnlyCollection<Item> Items
        {
            get { return items as IReadOnlyCollection<Item>; }
        }

        public int Capacity { get; private set; }

        public int Load => this.items.Sum(i => i.Weight);

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public Item GetItem(string name)
        {
            if (this.items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = this.items.FirstOrDefault(i => i.Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            return item;
        }

        public void AddItem(Item item)
        {
            if (this.Load+item.Weight>this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public void RemoveItem(string itemName)
        {
            var item = this.GetItem(itemName);
            this.items.Remove(item);
        }
    }
}
