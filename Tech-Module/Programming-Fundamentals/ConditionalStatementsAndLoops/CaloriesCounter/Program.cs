using System;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        int cals = 0;

        for (var i = 0; i < n; i++)
        {

            string ingr = Console.ReadLine().ToLower();

            switch (ingr)
            {
                case "cheese":

                    cals += 500;

                    break;

                case "salami":

                    cals += 600;

                    break;

                case "pepper":

                    cals += 50;

                    break;

                case "tomato sauce":

                    cals += 150;

                    break;

                default:

                    break;




            }

        }
        Console.WriteLine("Total calories: " + cals);
    }
}