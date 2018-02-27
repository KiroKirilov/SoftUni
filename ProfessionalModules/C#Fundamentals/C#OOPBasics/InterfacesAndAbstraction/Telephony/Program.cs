using System;


class Program
{
    static void Main(string[] args)
    {
        var phoneNumbers = Console.ReadLine().Split(' ');
        var siteURLs = Console.ReadLine().Split(' ');
        var phone = new SmartPhone();

        foreach (var number in phoneNumbers)
        {
            phone.CallNumber(number);
        }

        foreach (var url in siteURLs)
        {
            phone.BrowseSite(url);
        }
    }
}

