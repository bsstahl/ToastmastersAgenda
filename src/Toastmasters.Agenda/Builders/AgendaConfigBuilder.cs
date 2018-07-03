using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Builders
{
    public class AgendaConfigBuilder: Entities.AgendaConfig
    {
        public AgendaConfigBuilder Defaults()
        {
            return this.MeetingTimeFormat("hh:mm tt")
                .AgendaTimeFormat("hh:mm")
                .MeetingDateFormat("dddd, dd MMMM, yyyy")
                .PresidingOfficerIntroMinutes(2)
                .ToastmasterIntroMinutes(7)
                .EvaluationTimeMinutes(3)
                .FunctionaryReportMinutes(7)
                .ListenerMinutes(3)
                .MentorMinutes(3)
                .MinClubBusinessMinutes(5)
                .MinTableTopicsMinutes(5)
                .MaxTableTopicsMinutes(15);
        }

        public new AgendaConfigBuilder MeetingTimeFormat(string meetingTimeFormat)
        {
            base.MeetingTimeFormat = meetingTimeFormat;
            return this;
        }

        public new AgendaConfigBuilder AgendaTimeFormat(string agendaTimeFormat)
        {
            base.AgendaTimeFormat = agendaTimeFormat;
            return this;
        }

        public new AgendaConfigBuilder MeetingDateFormat(string meetingDateFormat)
        {
            base.MeetingDateFormat = meetingDateFormat;
            return this;
        }

        public new AgendaConfigBuilder PresidingOfficerIntroMinutes(int presidingOfficerIntroMinutes)
        {
            base.PresidingOfficerIntroMinutes = presidingOfficerIntroMinutes;
            return this;
        }

        public new AgendaConfigBuilder ToastmasterIntroMinutes(int toastmasterIntroMinutes)
        {
            base.ToastmasterIntroMinutes = toastmasterIntroMinutes;
            return this;
        }

        public new AgendaConfigBuilder EvaluationTimeMinutes(int evaluationTimeMinutes)
        {
            base.EvaluationTimeMinutes = evaluationTimeMinutes;
            return this;
        }

        public new AgendaConfigBuilder FunctionaryReportMinutes(int functionaryReportMinutes)
        {
            base.FunctionaryReportMinutes = functionaryReportMinutes;
            return this;
        }

        public new AgendaConfigBuilder ListenerMinutes(int listenterMinutes)
        {
            base.ListenerMinutes = listenterMinutes;
            return this;
        }

        public new AgendaConfigBuilder MentorMinutes(int mentorMinutes)
        {
            base.MentorMinutes = mentorMinutes;
            return this;
        }

        public new AgendaConfigBuilder MinClubBusinessMinutes(int minClubBusinessMinutes)
        {
            base.MinClubBusinessMinutes = minClubBusinessMinutes;
            return this;
        }

        public new AgendaConfigBuilder MinTableTopicsMinutes(int minTableTopicsMinutes)
        {
            base.MinTableTopicsMinutes = minTableTopicsMinutes;
            return this;
        }

        public new AgendaConfigBuilder MaxTableTopicsMinutes(int maxTableTopicsMinutes)
        {
            base.MaxTableTopicsMinutes = maxTableTopicsMinutes;
            return this;
        }


        public Entities.AgendaConfig Build()
        {
            return this;
        }
    }
}
