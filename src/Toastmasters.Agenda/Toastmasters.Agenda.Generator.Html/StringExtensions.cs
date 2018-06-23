using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Generator.Html
{
    public static class StringExtensions
    {
        public static string ReplaceField(this string template, string replacementSource, string replacementTarget)
        {
            return template.Replace(replacementSource, replacementTarget);
        }

        public static string ReplaceAddress(this string template, string replacementSource, string replacementTarget)
        {
            // Adds Zero-Length Spaces (&#8203;) after slashes or Underscores
            // in Addresses to allow them to line-break at that point
            string address = replacementTarget
                .Replace("/", "/&#8203;")
                .Replace("_", "_&#8203;");

            return template.Replace(replacementSource, address);
        }
    }
}
