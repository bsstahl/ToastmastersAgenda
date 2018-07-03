using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Web.Extensions;

namespace Toastmasters.Web
{
    public static class ValidateToastmasterCookieMiddleware
    {
        const string _parseErrorKey = "CookieParseError";
        const string _newCookieValueKey = "NewCookieValue";

        public static void UseValidateToastmasterCookie(this IApplicationBuilder app)
        {
            app.Use(async (context, next) => { await ValidateToastmasterCookie(context, next); });
        }

        public static async Task ValidateToastmasterCookie(Microsoft.AspNetCore.Http.HttpContext context, Func<Task> next)
        {
            Agenda.Entities.Config config;
            bool cookieModified = false;

            var cookie = context.Request.GetToastmastersCookie();
            if (cookie != null)
            {
                (bool ok, string message) = cookie.TryParseConfig();
                if (!ok)
                {
                    // Unable to parse config
                    cookie = null;
                    context.Items[_parseErrorKey] = message;
                }
            }

            if (cookie == null)
            {
                // Handle no valid cookie (didn't exist or couldn't be parsed)
                config = new Agenda.Entities.Config();
                config.Verson = 0.1f;
                config.AgendaConfig = new Agenda.Builders.AgendaConfigBuilder().Defaults().Build();
                config.ClubConfig = new Agenda.Builders.ClubBuilder().Defaults().Build();
                cookieModified = true;
            }
            else
            {
                // Parse valid cookie
                config = cookie.AsConfig();
            }

            if (config.AgendaConfig == null)
            {
                config.AgendaConfig = new Agenda.Builders.AgendaConfigBuilder().Defaults().Build();
                cookieModified = true;
            }

            if (config.ClubConfig == null)
            {
                config.ClubConfig = new Agenda.Builders.ClubBuilder().Defaults().Build();
                cookieModified = true;
            }

            if (config.ClubConfig.Officers == null)
            { 
                config.ClubConfig.Officers = new Agenda.Builders.ClubOfficerBuilder().Defaults().Build();
                cookieModified = true;
            }

            if (config.ClubConfig.MeetingLengthMinutes < 1)
            {
                config.ClubConfig.MeetingLengthMinutes = 60;
                cookieModified = true;
            }

            if (config.Verson == 0.0f)
            {
                // Upgrade from version 0.0 to version 0.1
                config.Verson = 0.1f;
                config.AgendaConfig.MinTableTopicsMinutes = 5;
                cookieModified = true;
            }

            if (cookieModified)
            {
                var configJson = config.AsJson();
                context.Items[_newCookieValueKey] = configJson;    // Store to be added to response later
                context.Request.AddToastmastersCookie(configJson); // Update the inbound request
            }

            await next.Invoke();

            if (context.Items.ContainsKey(_newCookieValueKey))
                context.Response.AddToastmastersCookie(context.Items[_newCookieValueKey].ToString());
        }

    }
}
