using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


public class DateModifier
{
    public void PrintDifference(string date1, string date2)
    {
        int[] d1 = date1.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] d2 = date2.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        DateTime dateOne = new DateTime(d1[0], d1[1], d1[2]);
        DateTime dateTwo = new DateTime(d2[0], d2[1], d2[2]);

        TimeSpan difference = dateOne.Subtract(dateTwo);
        Console.WriteLine(Math.Abs(difference.TotalDays));
    }

}

