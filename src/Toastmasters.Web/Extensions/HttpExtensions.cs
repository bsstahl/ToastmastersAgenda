using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toastmasters.Web.Extensions
{
    public static class HttpExtensions
    {
        const string _cookieName = "ToastmastersConfig";

        public static void AddToastmastersCookie(this HttpResponse response, string json)
        {
            var base64 = json.ToBase64();
            var cookie = new CookieOptions() { Expires = DateTime.Now.AddDays(3650) };
            response.Cookies.Append(_cookieName, base64, cookie);
        }

        public static void AddToastmastersCookie(this HttpRequest request, string json)
        {
            var originalCookies = request.Cookies.ToList();
            var updatedCookies = new System.Collections.Generic.Dictionary<string, string>();

            foreach (var cookie in originalCookies)
                if (cookie.Key != _cookieName)
                    updatedCookies.Add(cookie.Key, cookie.Value);

            updatedCookies.Add(_cookieName, json.ToBase64());

            request.Cookies = new Microsoft.AspNetCore.Http.Internal.RequestCookieCollection(updatedCookies);
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
