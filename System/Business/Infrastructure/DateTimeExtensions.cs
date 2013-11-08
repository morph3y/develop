using System;

namespace Business.Infrastructure
{
    public static class DateTimeExtensions
    {
        public static String ToShortDateStringEx(this DateTime dateTime)
        {
            return dateTime.Date.ToString("MM/dd/yyyy");
        }
    }
}
