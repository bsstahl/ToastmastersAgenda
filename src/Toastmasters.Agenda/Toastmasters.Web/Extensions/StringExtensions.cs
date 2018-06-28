using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Web.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string data)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(data);
            return System.Convert.ToBase64String(textBytes);
        }

        public static string FromBase64(this string base64data)
        {
            var base64Bytes = System.Convert.FromBase64String(base64data);
            return System.Text.Encoding.UTF8.GetString(base64Bytes);
        }

        public static Config AsConfig(this string jsonConfig)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(jsonConfig);
        }
    }
}
