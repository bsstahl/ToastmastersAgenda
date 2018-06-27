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

        public static string GetToastmastersCookie(this HttpRequest request)
        {
            var base64 = request.Cookies["ToastmastersConfig"];
            return base64.FromBase64();
        }
    }
}
