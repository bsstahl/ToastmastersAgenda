using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Meeting
    {
        public DateTime MeetingStartDateTime { get; set; }
        public DateTime MeetingEndDateTime { get; set; }

        public string PresidingOfficerName { get; set; }
        public string ToastmasterName { get; set; }
        public string Theme { get; set; }
        public string WordOfTheDay { get; set; }


        public string AhCounterName { get; set; }
        public string GrammarianName { get; set; }
        public string TimerName { get; set; }
        public string GeneralEvaluatorName { get; set; }
        public string ListenerName { get; set; }
        public string TopicMasterName { get; set; }
        public string MentorName { get; set; }


        public Speech Speech1 { get; set; }
        public Speech Speech2 { get; set; }

    }
}
