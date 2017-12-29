using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regexp_weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, string[]>();
            var pattern = @"([A-Z]{2})([0-9]+.[0-9]+)([A-Za-z]+)\|";
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "end") break;
                foreach (Match item in Regex.Matches(inputLine, pattern))
                {
                    if (cities.ContainsKey(item.Groups[1].ToString()))
                    {
                        cities[item.Groups[1].ToString()][0] = item.Groups[2].ToString();
                        cities[item.Groups[1].ToString()][1] = item.Groups[3].ToString();
                    }
                    else
                    {
                        cities.Add(item.Groups[1].ToString(), new string[2]);
                        cities[item.Groups[1].ToString()][0] = item.Groups[2].ToString();
                        cities[item.Groups[1].ToString()][1] = item.Groups[3].ToString();
                    }
                }
            }
            foreach (var item in cities.OrderBy(t => double.Parse(t.Value[0])))
            {
                Console.WriteLine("{0} => {1:f2} => {2}", item.Key, item.Value[0], item.Value[1]);
            }
        }
    }
}