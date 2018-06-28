using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class AgendaConfig
    {
        public AgendaConfig(bool loadDefaults = false)
        {
            if (loadDefaults)
                LoadDefaults();
        }

        public string MeetingTimeFormat { get; set; }
        public string AgendaTimeFormat { get; set; }
        public string MeetingDateFormat { get; set; }

        public int PresidingOfficerIntroMinutes { get; set; }
        public int ToastmasterIntroMinutes { get; set; }
        public int EvaluationTimeMinutes { get; set; }
        public int FunctionaryReportMinutes { get; set; }
        public int ListenerMinutes { get; set; }
        public int MentorMinutes { get; set; }

        public int MinClubBusinessMinutes { get; set; }

        public int MinTableTopicMinutes { get; set; }
        public int MaxTableTopicsMinutes { get; set; }


        private void LoadDefaults()
        {
            this.MeetingTimeFormat = "hh:mm tt";
            this.AgendaTimeFormat = "hh:mm";
            this.MeetingDateFormat = "dddd, dd MMMM, yyyy";
            
            this.PresidingOfficerIntroMinutes = 2;
            this.ToastmasterIntroMinutes = 7;
            this.EvaluationTimeMinutes = 2;
            this.FunctionaryReportMinutes = 7;
            this.ListenerMinutes = 3;
            this.MentorMinutes = 3;

            this.MinClubBusinessMinutes = 5;

            this.MinTableTopicMinutes = 5;
            this.MaxTableTopicsMinutes = 15;
        }
    }
}
