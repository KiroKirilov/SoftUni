using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static void Main()
    {
        var bagCapacity = long.Parse(Console.ReadLine());
        var itemInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var goldBag = new Dictionary<string, long>();
        long goldQuantity = 0;
        var gemBag = new Dictionary<string, long>();
        long gemQuantity = 0;
        var cashBag = new Dictionary<string, long>();
        long cashQuantity = 0;

        for (int i = 0; i < itemInput.Length; i += 2)
        {
            var itemName = itemInput[i];
            var itemAmount = long.Parse(itemInput[i + 1]);

            var itemType = GetItemType(itemName);

            var canInsertItem = CanInsertItem(itemType, itemAmount, bagCapacity, goldQuantity, gemQuantity, cashQuantity);

            if (itemType == "invalid" || !canInsertItem)
                continue;

            switch (itemType)
            {
                case "Gold":
                    InsertIntoBag(goldBag, itemName, itemAmount);
                    goldQuantity += itemAmount;
                    break;

                case "Gem":
                    InsertIntoBag(gemBag, itemName, itemAmount);
                    gemQuantity += itemAmount;
                    break;

                case "Cash":
                    InsertIntoBag(cashBag, itemName, itemAmount);
                    cashQuantity += itemAmount;
                    break;

            }
        }

        if (goldBag.Any())
        {
            Console.WriteLine(PrintBag(goldBag, "Gold", goldQuantity));
            if (gemBag.Any())
            {
                Console.WriteLine(PrintBag(gemBag, "Gem", gemQuantity));
                if (cashBag.Any())
                {
                    Console.WriteLine(PrintBag(cashBag, "Cash", cashQuantity));
                }
            }
        }
    }

    static string PrintBag(Dictionary<string, long> bag, string itemType, long quantity)
    {
        var output = new StringBuilder();

        output.AppendLine($"<{itemType}> ${quantity}");

        foreach (var item in bag.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
        {
            output.AppendLine($"##{item.Key} - {item.Value}");
        }

        return output.ToString().TrimEnd();
    }

    static void InsertIntoBag(Dictionary<string, long> bag, string itemName, long itemAmount)
    {
        if (!bag.ContainsKey(itemName))
        {
            bag.Add(itemName, 0);
        }

        bag[itemName] += itemAmount;
    }

    static bool CanInsertItem(string itemType, long itemAmount, long bagCapacity, long goldQuantity, long gemQuantity, long cashQuantity)
    {
        long inBagNow = goldQuantity + gemQuantity + cashQuantity;

        if (inBagNow + itemAmount > bagCapacity)
            return false;

        switch (itemType)
        {
            case "Gold":
                return true;

            case "Gem":
                gemQuantity += itemAmount;
                return gemQuantity <= goldQuantity;

            case "Cash":
                cashQuantity += itemAmount;
                return cashQuantity <= gemQuantity;
        }

        return false;
    }

    static string GetItemType(string itemName)
    {
        if (itemName.Length == 3)
            return "Cash";

        if (itemName.ToLower().EndsWith("gem"))
            return "Gem";

        if (itemName.ToLower() == "gold")
            return "Gold";

        return "invalid";
    }
}