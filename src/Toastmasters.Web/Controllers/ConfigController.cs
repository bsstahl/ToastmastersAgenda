using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toastmasters.Web.Extensions;

namespace Toastmasters.Web.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index(string errorMessage = "")
        {
            var configJson = this.HttpContext.Request.GetToastmastersCookie();

            ViewData["ErrorMessage"] = errorMessage;
            ViewData["ConfigJson"] = configJson;

            var config = configJson.AsConfig();
            return View(new Models.ConfigViewModel(config));
        }

        // POST: Config/Create - Postback from the Json config form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string config)
        {
            try
            {
                // Save cookie to browser
                var (parseResult, errorMessage) = config.TryParseConfig();
                if (parseResult)
                {
                    this.HttpContext.Items["NewCookieValue"] = config;
                    return RedirectToAction("Index", "Agenda");
                }
                else
                {
                    // Handle parse error on config
                    return RedirectToAction("Index", new { errorMessage = errorMessage });
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Config/Create - Postback from the individual items form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ConfigViewModel config)
        {
            // Validate model
            if (!this.ModelState.IsValid)
                return RedirectToAction("Index", new { configModel = config, configJson = "", errorMessage = "Unable to validate data" });
            else
            {
                this.HttpContext.Items["NewCookieValue"] = config.AsConfig().AsJson();
                return RedirectToAction("Index");
            }
        }

    }
}