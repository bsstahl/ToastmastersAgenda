using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Generator.Html
{
    public static class DateTimeExtensions
    {
        public static DateTime Min(this DateTime v1, DateTime v2)
        {
            DateTime result = v1;
            if (v2 < v1)
                result = v2;
            return result;
        }

        public static DateTime Max(this DateTime v1, DateTime v2)
        {
            DateTime result = v1;
            if (v2 > v1)
                result = v2;
            return result;
        }
    }
}
