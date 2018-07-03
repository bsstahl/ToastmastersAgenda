using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Builders
{
    public class MeetingBuilder: Entities.Meeting
    {

        public MeetingBuilder()
        {
            this.Speech1 = new Entities.Speech();
        }

        public new MeetingBuilder MentorName(string mentorName)
        {
            base.MentorName = mentorName;
            return this;
        }

        public Entities.Meeting Build()
        {
            return this;
        }
    }
}
