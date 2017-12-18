using System;
using System.Globalization;
using System.Linq;
class CountWorkingDays
{
    static void Main()
    {
        string startDateText = Console.ReadLine();
        string endDateText = Console.ReadLine();

        DateTime startDate = DateTime.ParseExact(startDateText, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        DateTime endDate = DateTime.ParseExact(endDateText, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        DateTime[] holidays = new DateTime[11];

        holidays[0] = new DateTime(2016, 01, 01);
        holidays[1] = new DateTime(2016, 03, 03);
        holidays[2] = new DateTime(2016, 05, 01);
        holidays[3] = new DateTime(2016, 05, 06);
        holidays[4] = new DateTime(2016, 05, 24);
        holidays[5] = new DateTime(2016, 09, 06);
        holidays[6] = new DateTime(2016, 09, 22);
        holidays[7] = new DateTime(2016, 11, 01);
        holidays[8] = new DateTime(2016, 12, 24);
        holidays[9] = new DateTime(2016, 12, 25);
        holidays[10] = new DateTime(2016, 12, 26);

        int workingDayCounter = 0;

        for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
        {
            DayOfWeek day = i.DayOfWeek;

            DateTime temp = new DateTime(2016, i.Month, i.Day);

            if (!holidays.Contains(temp) && (!day.Equals(DayOfWeek.Saturday) && !day.Equals(DayOfWeek.Sunday)))
            {
                workingDayCounter++;
            }
        }
        Console.WriteLine(workingDayCounter);
    }
}