using System;
using System.IO;
using Toastmasters.Agenda.Extensions;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFilePathFormat = @"..\..\..\..\..\..\..\..\..\Documents\Agendas\GeneratedAgenda_{0}.html";
            string outputFilePath = string.Format(outputFilePathFormat, Guid.NewGuid().ToString());

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
            config.MinTableTopicsMinutes = 5;
            config.MaxTableTopicsMinutes = 15;

            #endregion

            #region Club

            var club = new Toastmasters.Agenda.Entities.Club();
            club.Name = "Club Name Here";
            club.Number = "1234567";

            club.Officers = new Toastmasters.Agenda.Entities.Officers();
            club.Officers.PresidentName = "President's Name";
            club.Officers.VPEducationName = "VPE's Name";
            club.Officers.VPMembershipName = "VPM's Name";
            club.Officers.VPPublicRelationsName = "VPPR's Name";
            club.Officers.SecretaryName = "Secretary's Name";
            club.Officers.TreasurerName = "Treasurer's Name";
            club.Officers.SeargeantAtArmsName = "SAA's Name";

            club.WebsiteUrl = "https://www.ourcluburl.com";
            club.EmailAddress = "email@ourcluburl.com";
            club.SlackChannel = "#ourclubchannel";
            club.MissionStatement = "The mission of our Toastmasters club is to provide a mutually supportive and positive learning environment in which every individual member has the opportunity to develop oral communication and leadership skills, which in turn foster self-confidence and personal growth.";

            #endregion

            var meeting = new Toastmasters.Agenda.Entities.Meeting();
            meeting.MeetingStartDateTime = DateTime.Parse("2018-01-01 16:00");
            meeting.MeetingEndDateTime = DateTime.Parse("2018-01-01 17:00");

            meeting.PresidingOfficerName = "PO's Name";
            meeting.ToastmasterName = "TM's Name";
            meeting.Theme = "Meeting Theme";
            meeting.WordOfTheDay = "Word-of-the-day";

            meeting.AhCounterName = "AhCounter's Name";
            meeting.GrammarianName = "Grammarian's Name";
            meeting.TimerName = "Timer's Name";
            meeting.GeneralEvaluatorName = "GE's Name";
            meeting.ListenerName = "Listener's Name";
            meeting.TopicMasterName = "TopicMaster's Name";
            meeting.MentorName = "Mentor's Name";

            meeting.Speech1 = new Toastmasters.Agenda.Entities.Speech();
            meeting.Speech1.SpeakerName = "Speaker1's Name";
            meeting.Speech1.Title = "Speech 1 Title";
            meeting.Speech1.SpeechType = "Prepared Speech (5 to 7 Minutes)";
            meeting.Speech1.MinLengthMinutes = 5;
            meeting.Speech1.MaxLengthMinutes = 7;
            meeting.Speech1.EvaluatorName = "Evaluator1's Name";

            meeting.Speech2 = new Toastmasters.Agenda.Entities.Speech();
            meeting.Speech2.SpeakerName = "Speaker2's Name";
            meeting.Speech2.Title = "Speech 2 Title";
            meeting.Speech2.SpeechType = "Icebreaker Speech (4 to 6 Minutes)";
            meeting.Speech2.MinLengthMinutes = 4;
            meeting.Speech2.MaxLengthMinutes = 6;
            meeting.Speech2.EvaluatorName = "Evaluator2's Name";

            string templatePath = $".{Path.DirectorySeparatorChar}Media{Path.DirectorySeparatorChar}Template.html";
            var template = File.ReadAllText(templatePath);

            string bannerPath = $".{Path.DirectorySeparatorChar}Media{Path.DirectorySeparatorChar}Toastmasters Banner.jpg";
            var banner = File.ReadAllBytes(bannerPath);
            var encodedBanner = System.Convert.ToBase64String(banner);

            var gen = new Toastmasters.Agenda.Generator.Html.Engine(template, encodedBanner, "image/jpg");
            var result = gen.CreateAgenda(config, club, meeting);
            result.SaveToFile(outputFilePath);
        }
    }
}
