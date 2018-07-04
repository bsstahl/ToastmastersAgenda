using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Extensions
{
    public static class DateTimeExtensions
    {
        public static Single ToHours(this DateTime dateTime)
        {
            return Convert.ToSingle(dateTime.Hour + (dateTime.Minute / 60.0));
        }

        public static DateTime AsTime(this Single time)
        {
            return DateTime.MinValue.AddMinutes(time * 60.0);
        }
    }
}
