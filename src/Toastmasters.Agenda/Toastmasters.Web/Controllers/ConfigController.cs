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
        public ActionResult Index()
        {
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
                this.Response.AddToastmastersCookie(config);
                return RedirectToAction("Index", "Agenda");
            }
            catch
            {
                return View();
            }
        }

        // GET: Config/Delete
        // Removes the cookie from the browser
        public ActionResult Delete()
        {
            return View();
        }

    }
}