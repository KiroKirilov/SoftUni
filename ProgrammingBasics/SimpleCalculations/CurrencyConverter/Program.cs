using System;

class CurrencyConverter
{
    static void Main()
    {

        var bgn = 1.0;
        var usd = 1.79549;
        var eur = 1.95583;
        var gbp = 2.53405;
        var value = double.Parse(Console.ReadLine());
        var inputCurrency = Console.ReadLine();
        var outputCurrency = Console.ReadLine();

        switch (inputCurrency)
        {
            case "BGN":
                break;
            case "USD":
                value = (value * usd);
                break;
            case "EUR":
                value = (value * eur);
                break;
            case "GBP":
                value = (value * gbp);
                break;
            default:
                break;
        }


        switch (outputCurrency)
        {
            case "BGN":
                value = value / bgn;
                break;
            case "USD":
                value = value / usd;
                break;
            case "EUR":
                value = value / eur;
                break;
            case "GBP":
                value = value / gbp;
                break;
            default:
                break;
        }


        Console.WriteLine(Math.Round(value, 2));



    }
}
