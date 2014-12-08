namespace DateTimeServices
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    public class DateService : IDateService
    {
        public string GetDayOfWeek(DateTime date)
        {
            CultureInfo bg = new CultureInfo("bg-BG");
            string dayOfWeek = bg.DateTimeFormat.DayNames[(int)date.DayOfWeek];
            return dayOfWeek;
        }
    }
}
