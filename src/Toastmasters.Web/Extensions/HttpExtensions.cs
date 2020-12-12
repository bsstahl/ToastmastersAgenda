using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Toastmasters.Web.Extensions
{
    public static class HttpExtensions
    {
        const string _cookieName = "ToastmastersConfig";

        public static void AddToastmastersCookie(this HttpResponse response, string json)
        {
            if (!response.HasStarted)
            {
                var base64 = json.ToBase64();
                var cookie = new CookieOptions() { Expires = DateTime.Now.AddDays(3650) };
                response.Cookies.Append(_cookieName, base64, cookie);
            }
        }

        public static void AddToastmastersCookie(this HttpRequest request, string json)
        {
            request.Cookies = request.Cookies.AddCookie(_cookieName, json.ToBase64());
        }

        private static IRequestCookieCollection AddCookie(this IRequestCookieCollection originalCookies, string name, String value)
        {
            var updatedCookies = new System.Collections.Generic.List<KeyValuePair<string, string>>();

            foreach (var cookie in originalCookies)
                if (cookie.Key != _cookieName)
                    updatedCookies.Add(new KeyValuePair<string, string>(cookie.Key, cookie.Value));
            updatedCookies.Add(new KeyValuePair<string, string>(name, value));

            return new ToastmastersCookieCollection(updatedCookies);
        }

        public static string GetToastmastersCookie(this HttpRequest request)
        {
            var base64 = request.Cookies[_cookieName];
            string result = base64;
            if (!string.IsNullOrEmpty(base64))
                result = base64.FromBase64();
            return result;
        }

    }
}
