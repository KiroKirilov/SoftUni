using System;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            var pizzaInfo = Console.ReadLine().Split(' ');
            var pizzaName = pizzaInfo[1];
            var doughInfo = Console.ReadLine().Split(' ');
            var flour = doughInfo[1];
            var bakeTech = doughInfo[2];
            var doughWeight = int.Parse(doughInfo[3]);
            var dough = new Dough(flour, bakeTech, doughWeight);
            var pizza = new Pizza(pizzaName, dough);

            var toppingInput = "";

            while ((toppingInput = Console.ReadLine()) != "END")
            {
                var toppingInfo = toppingInput.Split(' ');
                var toppingType = toppingInfo[1];
                var toppingWeight = int.Parse(toppingInfo[2]);
                var topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}

