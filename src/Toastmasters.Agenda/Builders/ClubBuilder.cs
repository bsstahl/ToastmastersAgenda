using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Builders
{
    public class ClubBuilder: Entities.Club
    {
        public ClubBuilder()
        {
            base.Officers = new Entities.Officers();
        }

        public ClubBuilder Defaults()
        {
            return this.EmailAddress("email@ourcluburl.com")
                .MeetingDayOfWeek(DayOfWeek.Wednesday)
                .MeetingLengthMinutes(60)
                .MeetingMessage("")
                .MeetingStartTime(12.00f)
                .MissionStatement("The mission of our Toastmasters club is to provide a mutually supportive and positive learning environment in which every individual member has the opportunity to develop oral communication and leadership skills, which in turn foster self-confidence and personal growth.")
                .Name("Club Name")
                .Number("000000")
                .SlackChannel("#ourclubchannel")
                .WebsiteUrl("https://www.ourcluburl.com")
                .Officers(new Builders.ClubOfficerBuilder().Defaults().Build());
        }

        public new ClubBuilder Officers(Entities.Officers officers)
        {
            base.Officers = officers;
            return this;
        }

        public new ClubBuilder EmailAddress(string emailAddress)
        {
            base.EmailAddress = emailAddress;
            return this;
        }

        public new ClubBuilder MeetingDayOfWeek(DayOfWeek dayOfWeek)
        {
            base.MeetingDayOfWeek = dayOfWeek;
            return this;
        }

        public new ClubBuilder MeetingLengthMinutes(int meetingLengthMinutes)
        {
            base.MeetingLengthMinutes = meetingLengthMinutes;
            return this;
        }

        public new ClubBuilder MeetingMessage(string meetingMessage)
        {
            base.MeetingMessage = meetingMessage;
            return this;
        }

        public new ClubBuilder MeetingStartTime(Single meetingStartTime)
        {
            base.MeetingStartTime = meetingStartTime;
            return this;
        }

        public new ClubBuilder MissionStatement(string missionStatement)
        {
            base.MissionStatement = missionStatement;
            return this;
        }

        public new ClubBuilder Name(string name)
        {
            base.Name = name;
            return this;
        }

        public new ClubBuilder Number(string number)
        {
            base.Number = number;
            return this;
        }

        public new ClubBuilder SlackChannel(string slackChannel)
        {
            base.SlackChannel = slackChannel;
            return this;
        }

        public new ClubBuilder WebsiteUrl(string websiteUrl)
        {
            base.WebsiteUrl = websiteUrl;
            return this;
        }

        public Entities.Club Build()
        {
            return this;
        }
    }
}
