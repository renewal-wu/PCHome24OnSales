using System;

namespace PCHome24OnSales.API.Utility
{
    public class DateTimeHelper
    {
        public static DateTime GetFriday(DateTime sourceDateTime)
        {
            switch (sourceDateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return sourceDateTime.AddDays(-3);
                case DayOfWeek.Tuesday:
                    return sourceDateTime.AddDays(-4);
                case DayOfWeek.Wednesday:
                    return sourceDateTime.AddDays(-5);
                case DayOfWeek.Thursday:
                    return sourceDateTime.AddDays(-6);
                case DayOfWeek.Friday:
                    return sourceDateTime;
                case DayOfWeek.Saturday:
                    return sourceDateTime.AddDays(-1);
                case DayOfWeek.Sunday:
                    return sourceDateTime.AddDays(-2);
                default:
                    return sourceDateTime.AddDays(-1);
            }
        }
    }
}
