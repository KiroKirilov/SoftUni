using System;
using System.Globalization;

class CurrencyConverter
{
    static void Main()
    {
        var userInput = Console.ReadLine();
        DateTime dt = DateTime.ParseExact(userInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        dt = dt.AddDays(999);
        string text = dt.ToString("dd-MM-yyyy",
                                CultureInfo.InvariantCulture);
        Console.WriteLine(text);
    }
}
