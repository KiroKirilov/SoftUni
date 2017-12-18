using System;

public class Program
{
    public static void Main()
    {
        string word = Console.ReadLine();
        string last = word.Substring(word.Length - 1);
        string last2 = word.Substring(word.Length - 2);


        if (last == "y")
        {

            word = word.Remove(word.Length - 1);
            Console.WriteLine(word + "ies");

        }
        else if ((last == "o") || (last == "z") || (last == "x") || (last == "s") || (last2 == "ch") || (last2 == "sh"))
        {


            Console.WriteLine(word + "es");

        }
        else
        {

            Console.WriteLine(word + "s");

        }
    }
}