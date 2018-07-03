using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toastmasters.Agenda.Entities;
using Toastmasters.Web.Models;
using Toastmasters.Web.Extensions;

namespace Toastmasters.Web.Controllers
{
    public class AgendaController : Controller
    {
        AgendaConfig _agendaConfig;
        Club _clubConfig;

        [HttpGet]
        public IActionResult Index()
        {
            LoadConfiguration();

            // TODO: Check if we already have this information
            // from a previous execution and use that if available
            var viewModel = new AgendaViewModel(_agendaConfig, _clubConfig);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(AgendaViewModel agenda)
        {
            LoadConfiguration();

            Agenda.Entities.Meeting meeting = agenda.AsEntity();
            string templatePath = $".{System.IO.Path.DirectorySeparatorChar}Media{System.IO.Path.DirectorySeparatorChar}Template.html";
            var template = System.IO.File.ReadAllText(templatePath);

            string bannerPath = $".{System.IO.Path.DirectorySeparatorChar}Media{System.IO.Path.DirectorySeparatorChar}Toastmasters Banner.jpg";
            var banner = System.IO.File.ReadAllBytes(bannerPath);
            var encodedBanner = System.Convert.ToBase64String(banner);

            var gen = new Toastmasters.Agenda.Generator.Html.Engine(template, encodedBanner, "image/jpg");
            var result = gen.CreateAgenda(_agendaConfig, _clubConfig, meeting);
            return new FileStreamResult(result, "text/html");
        }

        private void LoadConfiguration()
        {
            // If a cookie exists, reload configs from the cookie
            var cookie = this.Request.GetToastmastersCookie();
            if (cookie != null)
            {
                var configs = cookie.AsConfig();
                _agendaConfig = configs.AgendaConfig;
                _clubConfig = configs.ClubConfig;
            }

            if (_agendaConfig == null)
                _agendaConfig = new Agenda.Builders.AgendaConfigBuilder().Defaults().Build();

            if (_clubConfig == null)
                _clubConfig = new Agenda.Builders.ClubBuilder().Defaults().Build();
        }

    }
}
