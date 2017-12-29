using System;
using System.Collections.Generic;
using System.Linq;

public class SrabskoUnleashed
{
    public static void Main()
    {
        var venuesSingersMoney = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            string inputString = Console.ReadLine();
            if (inputString == "End")
            {
                break;
            }
            
            if (inputString.IndexOfAny(@"!~#$%^&*()_+<>?/|/""\:;`'".ToCharArray()) != -1)
            {
                continue;
            }

            var rawInputList = inputString.Split(new char[] { ' ' }).ToList();
            
            bool invalidInput = false;
            for (int i = 0; i < rawInputList.Count - 1; i++)
            {
                if (rawInputList[i] == string.Empty && rawInputList[i + 1] == string.Empty)
                {
                    invalidInput = true;
                }
            }

            if (invalidInput)
            {
                continue;
            }
            
            List<string> input = new List<string>();
            foreach (string item in rawInputList)
            {
                if (item != string.Empty)
                {
                    input.Add(item);
                }
            }

            int ticketsPrice = 0;
            int ticketsCount = 0;
            
            if (input.Count < 4)
            {
                continue;
            }

            if (!int.TryParse(input[input.Count - 1], out ticketsCount) ||
                !int.TryParse(input[input.Count - 2], out ticketsPrice))
            {
                continue;
            }
            
            input.RemoveAt(input.Count - 1);
            input.RemoveAt(input.Count - 1);
            
            invalidInput = true;
            foreach (string item in input)
            {
                if (item[0] == '@')
                {
                    invalidInput = false;
                    break;
                }
            }

            if (invalidInput)
            {
                continue;
            }

            string singerName = string.Empty;
            string venueName = string.Empty;
            int venueNameLength = 1;
            
            for (int i = 0; i < input.Count; i++)
            {
                string word = input[i];
                if (word[0] == '@')
                {
                    venueName = word.Remove(0, 1);
                    for (int j = i + 1; j < input.Count; j++)
                    {
                        venueName += " " + input[j];
                        venueNameLength++;
                    }

                    input.RemoveRange(i, venueNameLength);
                }
            }
            
            if (venueNameLength > 3 ||
                input.Count > 3 ||
                input.Count == 0)
            {
                continue;
            }
            
            singerName = string.Join(" ", input);
            
            if (!venuesSingersMoney.ContainsKey(venueName))
            {
                venuesSingersMoney[venueName] = new Dictionary<string, long>();
            }

            if (!venuesSingersMoney[venueName].ContainsKey(singerName))
            {
                venuesSingersMoney[venueName][singerName] = ticketsCount * ticketsPrice;
            }
            else
            {
                venuesSingersMoney[venueName][singerName] += ticketsPrice * ticketsCount;
            }
        }

        foreach (var venue in venuesSingersMoney)
        {
            Console.WriteLine(venue.Key);
            foreach (var singer in venuesSingersMoney[venue.Key].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {singer.Key} -> {singer.Value }");
            }
        }
    }
}