using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Toastmasters.Web.Models;

namespace Toastmasters.Web.Controllers
{
    public class AgendaController : Controller
    {
        AgendaDefaultsModel _defaults;
        Agenda.Entities.Officers _officers;

        public AgendaController()
        {
            // TODO: Load from somewhere appropriate

            _officers = new Agenda.Entities.Officers();
            _officers.PresidentName = "Club President";
            _officers.VPEducationName = "Club VP Education";
            _officers.VPMembershipName = "Club VP Membership";
            _officers.VPPublicRelationsName = "Club VP PR";
            _officers.SecretaryName = "Club Secretary";
            _officers.TreasurerName = "Club Treasurer";
            _officers.SeargeantAtArmsName = "Sergeant-At-Arms";

            _defaults = new AgendaDefaultsModel()
            {
                MeetingDayOfWeek = DayOfWeek.Thursday,
                MeetingStartTime = 12.0f,
                MeetingLengthMinutes = 60,
                OfficerNames = _officers.AsEnumerable()
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            // TODO: Check if we already have this information
            // from a previous execution and use that if available
            var viewModel = new AgendaViewModel(_defaults);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(AgendaViewModel agenda)
        {
            #region Config

            var config = new Toastmasters.Agenda.Entities.AgendaConfig();
            config.MeetingTimeFormat = "hh:mm tt";
            config.AgendaTimeFormat = "hh:mm";
            config.MeetingDateFormat = "dddd, dd MMMM, yyyy";

            config.PresidingOfficerIntroMinutes = 2;
            config.ToastmasterIntroMinutes = 7;
            config.EvaluationTimeMinutes = 2;
            config.FunctionaryReportMinutes = 7;
            config.ListenerMinutes = 3;
            config.MentorMinutes = 3;

            config.MinClubBusinessMinutes = 5;
            config.MinTableTopicMinutes = 5;
            config.MaxTableTopicsMinutes = 15;

            #endregion

            #region Club

            var club = new Toastmasters.Agenda.Entities.Club();
            club.Name = "Our Club Name";
            club.Number = "1234567";

            club.Officers = _officers;
            club.WebsiteUrl = "https://www.ourclub.com";
            club.EmailAddress = "email@ourclub.com";
            club.SlackChannel = "#our-slack-channel";
            club.MissionStatement = "The mission of our Toastmasters club is to provide a mutually supportive and positive learning environment in which every individual member has the opportunity to develop oral communication and leadership skills, which in turn foster self-confidence and personal growth.";

            #endregion

            var meeting = new Toastmasters.Agenda.Entities.Meeting();
            meeting.MeetingStartDateTime = agenda.MeetingStartTime;
            meeting.MeetingEndDateTime = agenda.MeetingStartTime.AddMinutes(agenda.MeetingLength);

            meeting.PresidingOfficerName = agenda.PresidingOfficerName;
            meeting.ToastmasterName = agenda.ToastmasterName;
            meeting.Theme = agenda.MeetingTheme;
            meeting.WordOfTheDay = agenda.WordOfTheDay;

            meeting.AhCounterName = agenda.AhCounterName;
            meeting.GrammarianName = agenda.GrammarianName;
            meeting.TimerName = agenda.TimerName;
            meeting.GeneralEvaluatorName = agenda.GeneralEvaluatorName;
            meeting.ListenerName = agenda.ListenerName;
            meeting.TopicMasterName = agenda.TopicMasterName;
            meeting.MentorName = agenda.MentorName;

            meeting.Speech1 = GetSpeech(agenda.Speaker1Name, agenda.Speech1Title, agenda.Speech1Evaluator, agenda.Speech1Type);
            if (agenda.Speech2Type > 0)
                meeting.Speech2 = GetSpeech(agenda.Speaker2Name, agenda.Speech2Title, agenda.Speech2Evaluator, agenda.Speech2Type);

            var gen = new Toastmasters.Agenda.Generator.Html.Engine();
            var result = gen.CreateAgenda(config, club, meeting);

            return new FileStreamResult(result, "text/html");
        }

        private Agenda.Entities.Speech GetSpeech(string name, string title, string evaluator, int speechType)
        {
            var result = new Toastmasters.Agenda.Entities.Speech();
            result.SpeakerName = name;
            result.Title = title;
            result.EvaluatorName = evaluator;

            if (speechType == 1)
            {
                result.SpeechType = "Icebreaker Speech (4 to 6 Minutes)";
                result.MinLengthMinutes = 4;
                result.MaxLengthMinutes = 6;
            }
            else if (speechType == 2)
            {
                result.SpeechType = "Prepared Speech (5 to 7 Minutes)";
                result.MinLengthMinutes = 5;
                result.MaxLengthMinutes = 7;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(speechType));

            return result;
        }

    }
}
