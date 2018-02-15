using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var input = "";

        var catInfo = new Dictionary<string, Cat>();

        while ((input=Console.ReadLine())!="End")
        {
            var data = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var name = data[1];
            var type = data[0];
            var prop = data[2];

            if (!catInfo.ContainsKey(name))
            {
                catInfo.Add(name,new Cat(name,type,prop));
            }
        }

        var catToPrint = Console.ReadLine();

        Console.WriteLine(catInfo[catToPrint]);
    }
}

