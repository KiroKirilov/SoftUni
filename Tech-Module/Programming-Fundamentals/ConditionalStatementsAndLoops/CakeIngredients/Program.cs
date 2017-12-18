using System;

public class Program
{
    public static void Main()
    {
        int ingrAmount = 0;

        while (true)
        {

            string ingr = Console.ReadLine();

            if (ingr == "Bake!") break;
            else
            {
                Console.WriteLine("Adding ingredient {0}.", ingr);
            }

            ingrAmount++;
        }
        Console.WriteLine("Preparing cake with {0} ingredients.", ingrAmount);
    }
}