using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class AgendaConfig
    {
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
    }
}
