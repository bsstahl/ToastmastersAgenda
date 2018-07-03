using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Web.Extensions
{
    public static class ConfigExtensions
    {

        public static string AsConfigCookieValue(this Config config)
        {
            return config.AsJson().ToBase64();
        }

        public static string AsJson(this Config config)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(config);
        }

        public static Config AsConfig(this string jsonConfig)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(jsonConfig);
        }

        public static (bool, string) TryParseConfig(this string jsonConfig)
        {
            bool result = false;
            string errorMessage = string.Empty;
            try
            {
                var config = jsonConfig.AsConfig();
                result = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                result = false;
            }

            return (result, errorMessage);
        }

    }
}
