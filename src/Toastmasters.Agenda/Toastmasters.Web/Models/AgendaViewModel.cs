using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using Toastmasters.Agenda.Entities;
using Toastmasters.Web.Extensions;

namespace Toastmasters.Web.Models
{
    public class AgendaViewModel
    {
        public AgendaViewModel() { }

        public AgendaViewModel(AgendaDefaultsModel defaults)
        {
            this.MeetingStartTime = defaults.MeetingStartDateTime();
            this.MeetingLength = defaults.MeetingLengthMinutes;
            this.OfficerNames = defaults.OfficerNames;
        }

        public IEnumerable<string> OfficerNames { get; set; }

        [DisplayName("Meeting Start Date/Time (local)")]
        public DateTime MeetingStartTime { get; set; }

        [DisplayName("Meeting Length (min)")]
        public int MeetingLength { get; set; }

        [DisplayName("Presiding Officer")]
        public string PresidingOfficerName { get; set; }

        [DisplayName("Toastmaster")]
        public string ToastmasterName { get; set; }

        [DisplayName("Ah-Counter")]
        public string AhCounterName { get; set; }

        [DisplayName("Grammarian")]
        public string GrammarianName { get; set; }

        [DisplayName("Timer")]
        public string TimerName { get; set; }

        [DisplayName("General Evaluator")]
        public string GeneralEvaluatorName { get; set; }

        [DisplayName("Listener")]
        public string ListenerName { get; set; }

        [DisplayName("Topic Master")]
        public string TopicMasterName { get; set; }

        [DisplayName("Mentor")]
        public string MentorName { get; set; }

        [DisplayName("Meeting Theme")]
        public string MeetingTheme { get; set; }

        [DisplayName("Word of the Day")]
        public string WordOfTheDay { get; set; }

        public string Speaker1Name { get; set; }
        public string Speaker2Name { get; set; }

        public string Speech1Title { get; set; }
        public string Speech2Title { get; set; }

        public int Speech1Type { get; set; }
        public int Speech2Type { get; set; }

        public string Speech1Evaluator { get; set; }
        public string Speech2Evaluator { get; set; }



        public Agenda.Entities.Meeting AsEntity()
        {
            var meeting = new Toastmasters.Agenda.Entities.Meeting();
            meeting.MeetingStartDateTime = this.MeetingStartTime;
            meeting.MeetingEndDateTime = this.MeetingStartTime.AddMinutes(this.MeetingLength);

            meeting.PresidingOfficerName = this.PresidingOfficerName;
            meeting.ToastmasterName = this.ToastmasterName;
            meeting.Theme = this.MeetingTheme;
            meeting.WordOfTheDay = this.WordOfTheDay;

            meeting.AhCounterName = this.AhCounterName;
            meeting.GrammarianName = this.GrammarianName;
            meeting.TimerName = this.TimerName;
            meeting.GeneralEvaluatorName = this.GeneralEvaluatorName;
            meeting.ListenerName = this.ListenerName;
            meeting.TopicMasterName = this.TopicMasterName;
            meeting.MentorName = this.MentorName;

            meeting.Speech1 = (default(Speech)).Create(this.Speaker1Name, this.Speech1Title, this.Speech1Evaluator, this.Speech1Type);
            if (this.Speech2Type > 0)
                meeting.Speech2 = (default(Speech)).Create(this.Speaker2Name, this.Speech2Title, this.Speech2Evaluator, this.Speech2Type);

            return meeting;
        }


    }
}
