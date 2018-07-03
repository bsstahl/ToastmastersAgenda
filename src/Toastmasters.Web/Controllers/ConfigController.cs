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
            ViewData["ErrorMessage"] = errorMessage;
            ViewData["ConfigJson"] = this.HttpContext.Request.GetToastmastersCookie();
            return View();
        }

        // POST: Config/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string config)
        {
            try
            {
                // TODO: Save cookie to browser
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

        // GET: Config/Delete
        // Removes the cookie from the browser
        // Is this really the right thing? Should it be a return to default? Should it even exist?
        public ActionResult Delete()
        {
            return View(); // TODO: Implement
        }

    }
}