using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Club
    {
        public Club(bool loadDefaults = false)
        {
            if (loadDefaults)
                LoadDefaults();
        }

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


        private void LoadDefaults()
        {
            this.Name = "Our Club Name";
            this.Number = "1234567";

            this.MeetingDayOfWeek = DayOfWeek.Wednesday;
            this.MeetingStartTime = 12.0f;
            this.MeetingLengthMinutes = 60;

            this.MeetingMessage = "";
            this.WebsiteUrl = "https://www.ourclub.com";
            this.EmailAddress = "email@ourclub.com";
            this.SlackChannel = "#our-slack-channel";
            this.MissionStatement = "The mission of our Toastmasters club is to provide a mutually supportive and positive learning environment in which every individual member has the opportunity to develop oral communication and leadership skills, which in turn foster self-confidence and personal growth.";

            this.Officers = new Officers(true);
        }
    }
}
