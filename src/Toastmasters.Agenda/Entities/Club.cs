using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Club
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public DayOfWeek MeetingDayOfWeek { get; set; }
        public Single MeetingStartTime { get; set; }
        public int MeetingLengthMinutes { get; set; }


        public string MeetingMessage { get; set; }

        public string WebsiteUrl { get; set; }
        public string EmailAddress { get; set; }
        public string SlackChannel { get; set; }

        public string MissionStatement { get; set; }

        public Officers Officers { get; set; }
    }
}
