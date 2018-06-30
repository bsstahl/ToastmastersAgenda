using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Generator.Html.Test
{
    public static class Extensions
    {
        public static string AsString(this System.IO.Stream stream)
        {
            var reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
