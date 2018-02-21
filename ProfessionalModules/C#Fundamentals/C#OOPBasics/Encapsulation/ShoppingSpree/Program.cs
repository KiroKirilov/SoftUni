using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var people = new Dictionary<string, Person>();

            for (int i = 0; i < peopleInput.Length; i++)
            {
                var personData = peopleInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Person(name, money));
                }
            }

            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var products = new Dictionary<string, Product>();
            for (int i = 0; i < productsInput.Length; i++)
            {
                var productData = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = productData[0];
                var money = decimal.Parse(productData[1]);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, new Product(name, money));
                }
            }

            var input = "";
            while ((input=Console.ReadLine())!= "END")
            {
                var purchaseInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var personName = purchaseInfo[0];
                var productName = purchaseInfo[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    if (people[personName].CanPersonAffordItem(products[productName]))
                    {
                        people[personName].AddItemToBag(products[productName]);
                        Console.WriteLine($"{people[personName].Name} bought {products[productName].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{people[personName].Name} can't afford {products[productName].Name}");
                    }
                }
            }

            foreach (var person in people)
            {
                if (person.Value.ShoppingBag.Count>0)
                {
                    Console.WriteLine($"{person.Key} - {String.Join(", ",person.Value.ShoppingBag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Key} - Nothing bought");
                }
            }
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}

