using System;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            var animalType = Console.ReadLine();
            if (animalType == "Beast!")
                break;

            var animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var animalName = animalInfo[0];
            var animalAge=int.Parse(animalInfo[1]);
            var animal = new Animal("NoName", 0, "faggot");
            try
            {
                switch (animalType)
                {
                    case "Cat": animal = new Cat(animalName, animalAge, animalInfo[2]); break;
                    case "Dog": animal = new Dog(animalName, animalAge, animalInfo[2]); break;
                    case "Frog": animal = new Frog(animalName, animalAge, animalInfo[2]); break;
                    case "Kitten": animal = new Kitten(animalName, animalAge); break;
                    case "Tomcat": animal = new Tomcat(animalName, animalAge); break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
                Console.WriteLine(animal);
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(argex.Message);
            }
        }
    }
}
