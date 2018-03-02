using System;
using System.Collections.Generic;

class Program
{
    static List<Animal> animals;

    static void Main(string[] args)
    {
        var input = "";
        animals = new List<Animal>();

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

            switch (animalType.ToLower())
            {
                case "mouse":
                    var mouse = new Mouse(animalName, animalType, animalWeight, animalRegion);
                    EatFood(mouse, currentFood);
                    break;

                case "dog":
                    var dog = new Dog(animalName, animalType, animalWeight, animalRegion);
                    EatFood(dog, currentFood);
                    break;

                case "tiger":
                    var tigerBreed = animalInfo[4];
                    var tiger = new Tiger(animalName,animalType ,animalWeight, animalRegion,tigerBreed);
                    EatFood(tiger, currentFood);
                    break;

                case "cat":
                    var catBreed = animalInfo[4];
                    var cat = new Cat(animalName, animalType, animalWeight, animalRegion,catBreed);
                    EatFood(cat, currentFood);
                    break;

                case "hen":
                    //Owl Toncho 2.5 30
                    //         weight  wingsize
                    var henWingSize = double.Parse(animalInfo[3]);
                    var hen = new Hen(animalName, animalType, animalWeight, henWingSize);
                    EatFood(hen, currentFood);
                    break;

                case "owl":
                    var owlWingSize = double.Parse(animalInfo[3]);
                    var owl = new Owl(animalName, animalType, animalWeight, owlWingSize);
                    EatFood(owl, currentFood);
                    break;
                default:
                    break;
            }
        }

        foreach (var a in animals)
        {
            Console.WriteLine(a);
        }
    }

    private static void EatFood(Animal animal, Food currentFood)
    {
        animal.MakeSound();
        animal.Eat(currentFood);
        animals.Add(animal);
    }
}

