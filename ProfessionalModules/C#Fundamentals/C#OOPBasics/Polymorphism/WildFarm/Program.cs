using System;


class Program
{
    static void Main(string[] args)
    {
        var input = "";

        while ((input=Console.ReadLine())!="End")
        {
            var animalInfo = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var foodInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var foodType = foodInfo[0];
            var foodQuant = int.Parse(foodInfo[1]);
            Food currentFood;

            if (foodType == "Meat")
                currentFood = new Meat(foodQuant);
            else
                currentFood = new Vegetable(foodQuant);

            var animalType = animalInfo[0];
            var animalName = animalInfo[1];
            var animalWeight = double.Parse(animalInfo[2]);
            var animalRegion = animalInfo[3];

            switch (animalType)
            {
                case "Mouse":
                    var mouse = new Mouse(animalName, animalType, animalWeight, animalRegion);
                    EatFood(mouse, currentFood);
                    break;

                case "Zebra":
                    var zebra = new Zebra(animalName, animalType, animalWeight, animalRegion);
                    EatFood(zebra, currentFood);
                    break;

                case "Tiger":
                    var tiger = new Tiger(animalName,animalType ,animalWeight, animalRegion);
                    EatFood(tiger, currentFood);
                    break;

                case "Cat":
                    var catBreed = animalInfo[4];
                    var cat = new Cat(animalName, animalType, animalWeight, animalRegion,catBreed);
                    EatFood(cat, currentFood);
                    break;
                default:
                    break;
            }
        }
    }

    private static void EatFood(Animal animal, Food currentFood)
    {
        animal.MakeSound();
        animal.Eat(currentFood);
        Console.WriteLine(animal);
    }
}

