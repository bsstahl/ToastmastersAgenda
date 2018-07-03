using System;

namespace CreateConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = Newtonsoft.Json.JsonConvert.SerializeObject(args);
            if (args.Length > 1)
                throw new ArgumentException($"Too many arguments specified '{arguments}'");

            #region AgendaConfig

            var agendaConfig = new Toastmasters.Agenda.Entities.AgendaConfig();
            agendaConfig.MeetingTimeFormat = "hh:mm tt";
            agendaConfig.AgendaTimeFormat = "hh:mm";
            agendaConfig.MeetingDateFormat = "dddd, dd MMMM, yyyy";

            agendaConfig.PresidingOfficerIntroMinutes = 2;
            agendaConfig.ToastmasterIntroMinutes = 7;
            agendaConfig.EvaluationTimeMinutes = 2;
            agendaConfig.FunctionaryReportMinutes = 7;
            agendaConfig.ListenerMinutes = 3;
            agendaConfig.MentorMinutes = 3;

            agendaConfig.MinClubBusinessMinutes = 5;
            agendaConfig.MinTableTopicsMinutes = 5;
            agendaConfig.MaxTableTopicsMinutes = 15;

            #endregion

            #region ClubConfig

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

            var config = new Toastmasters.Agenda.Entities.Config()
            {
                ClubConfig = club,
                AgendaConfig = agendaConfig
            };


            string path = @".\ToastmastersConfig.json";
            if (args.Length == 1) path = args[0];
            string fullPath = System.IO.Path.GetFullPath(path);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(config);
            System.IO.File.WriteAllText(fullPath, json);
            Console.WriteLine($"Config file written to '{fullPath}'.");
        }
    }
}
