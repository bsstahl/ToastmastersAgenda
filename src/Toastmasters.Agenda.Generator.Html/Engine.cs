using System;
using System.IO;
using System.Text;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Agenda.Generator.Html
{
    public class Engine : Interfaces.IAgendaGenerator
    {
        string _htmlTemplate;
        string _bannerImage;
        string _bannerContentType;

        public Engine(string htmlTemplate, string bannerImage, string bannerContentType)
        {
            _htmlTemplate = htmlTemplate;
            _bannerImage = bannerImage;
            _bannerContentType = bannerContentType;
        }

        public System.IO.Stream CreateAgenda(AgendaConfig config, Club club, Meeting meeting)
        {
            string speech2Title = string.Empty;
            string speech2SpeakerName = string.Empty;
            string speech2SpeechType = string.Empty;
            string evaluator2Name = string.Empty;

            bool useMentorTime = !string.IsNullOrWhiteSpace(meeting.MentorName);
            string mentorItemStyle = "AgendaItem";
            string mentorDetailStyle = "AgendaDetails";
            int mentorTimeToUse = config.MentorMinutes;
            if (!useMentorTime)
            {
                mentorTimeToUse = 0;
                mentorItemStyle = "InactiveDetails";
                mentorDetailStyle = "InactiveDetails";
            }


            var twoSpeeches = (meeting.Speech2 != null);
            string speakerIntroduction = "Toastmaster Introduces Speaker";
            string evaluationIntroduction = "Toastmaster Introduces Evaluator (2-3 minutes)";
            string speech2Style = "InactiveDetails";
            int speechMinutes = meeting.Speech1.MaxLengthMinutes + config.EvaluationTimeMinutes;
            int evaluationMinutes = config.EvaluationTimeMinutes;
            if (twoSpeeches)
            {
                speakerIntroduction = "Toastmaster Introduces Speakers";
                evaluationIntroduction = "Toastmaster Introduces Evaluators (2-3 min ea)";
                speech2Style = "AgendaDetails";
                speechMinutes += meeting.Speech2.MaxLengthMinutes + config.EvaluationTimeMinutes;
                speech2Title = meeting.Speech2.Title;
                speech2SpeakerName = meeting.Speech2.SpeakerName;
                speech2SpeechType = meeting.Speech2.SpeechType;
                evaluator2Name = meeting.Speech2.EvaluatorName;
                evaluationMinutes += config.EvaluationTimeMinutes;
            }

            int backendMinutes = config.MinClubBusinessMinutes +
                mentorTimeToUse + config.ListenerMinutes +
                config.FunctionaryReportMinutes + evaluationMinutes;

            DateTime start = meeting.MeetingStartDateTime;
            DateTime end = meeting.MeetingEndDateTime;
            DateTime toastmasterTakeover = start.AddMinutes(config.PresidingOfficerIntroMinutes);
            DateTime speech1 = toastmasterTakeover.AddMinutes(config.ToastmasterIntroMinutes);
            DateTime tableTopics = speech1.AddMinutes(speechMinutes);

            DateTime minBackend = meeting.MeetingEndDateTime.AddMinutes(-backendMinutes);
            DateTime minTableTopics = tableTopics.AddMinutes(config.MinTableTopicMinutes);
            DateTime maxTableTopics = tableTopics.AddMinutes(config.MaxTableTopicsMinutes);

            DateTime evaluations = DetermineTableTopicsEnd(minBackend, minTableTopics, maxTableTopics);
            DateTime funcReports = evaluations.AddMinutes(evaluationMinutes);
            DateTime listener = funcReports.AddMinutes(config.FunctionaryReportMinutes);
            DateTime mentor = listener.AddMinutes(config.ListenerMinutes);
            DateTime poReturn = mentor.AddMinutes(mentorTimeToUse);

            string meetingDate = start.ToString(config.MeetingDateFormat);
            string meetingStartTime = start.ToString(config.MeetingTimeFormat);
            string meetingEndTime = end.ToString(config.MeetingTimeFormat);
            string agendaStartTime = start.ToString(config.AgendaTimeFormat);
            string toastmasterTakeoverTime = toastmasterTakeover.ToString(config.AgendaTimeFormat);
            string speech1Time = speech1.ToString(config.AgendaTimeFormat);
            string tableTopicsTime = tableTopics.ToString(config.AgendaTimeFormat);
            string evalTime = evaluations.ToString(config.AgendaTimeFormat);
            string funcReportTime = funcReports.ToString(config.AgendaTimeFormat);
            string listenerTime = listener.ToString(config.AgendaTimeFormat);
            string mentorTime = mentor.ToString(config.AgendaTimeFormat);
            string poReturnTime = poReturn.ToString(config.AgendaTimeFormat);

            var agenda = _htmlTemplate
                .ReplaceField("{BannerImage}", _bannerImage)
                .ReplaceField("{BannerContentType}", _bannerContentType)
                .ReplaceField("{ClubName}", club.Name)
                .ReplaceField("{PresidentName}", club.Officers.PresidentName)
                .ReplaceField("{VPEName}", club.Officers.VPEducationName)
                .ReplaceField("{VPMName}", club.Officers.VPMembershipName)
                .ReplaceField("{VPPRName}", club.Officers.VPPublicRelationsName)
                .ReplaceField("{SecName}", club.Officers.SecretaryName)
                .ReplaceField("{TreasName}", club.Officers.TreasurerName)
                .ReplaceField("{SEAName}", club.Officers.SeargeantAtArmsName)
                .ReplaceField("{MeetingMessage}", club.MeetingMessage)
                .ReplaceField("{WebsiteUrl}", club.WebsiteUrl)
                .ReplaceField("{EmailUrl}", club.EmailAddress)
                .ReplaceAddress("{WebsiteAddress}", club.WebsiteUrl)
                .ReplaceAddress("{EmailAddress}", club.EmailAddress)
                .ReplaceField("{SlackChannel}", club.SlackChannel)
                .ReplaceField("{ClubMissionStatement}", club.MissionStatement)
                .ReplaceField("{ClubNumber}", club.Number)
                .ReplaceField("{MeetingDate}", meetingDate)
                .ReplaceField("{MeetingStartTime}", meetingStartTime)
                .ReplaceField("{AgendaStartTime}", agendaStartTime)
                .ReplaceField("{Speech1Time}", speech1Time)
                .ReplaceField("{ToastmasterTakeoverTime}", toastmasterTakeoverTime)
                .ReplaceField("{TableTopicsTime}", tableTopicsTime)
                .ReplaceField("{MeetingEndTime}", meetingEndTime)
                .ReplaceField("{POName}", meeting.PresidingOfficerName)
                .ReplaceField("{TMName}", meeting.ToastmasterName)
                .ReplaceField("{AhCounterName}", meeting.AhCounterName)
                .ReplaceField("{GrammarianName}", meeting.GrammarianName)
                .ReplaceField("{TimerName}", meeting.TimerName)
                .ReplaceField("{GeneralEvaluatorName}", meeting.GeneralEvaluatorName)
                .ReplaceField("{ListenerName}", meeting.ListenerName)
                .ReplaceField("{MeetingTheme}", meeting.Theme)
                .ReplaceField("{WordOfTheDay}", meeting.WordOfTheDay)
                .ReplaceField("{Speech1Title}", meeting.Speech1.Title)
                .ReplaceField("{Speaker1Name}", meeting.Speech1.SpeakerName)
                .ReplaceField("{Speech1Type}", meeting.Speech1.SpeechType)
                .ReplaceField("{Speech2Style}", speech2Style)
                .ReplaceField("{Speech2Title}", speech2Title)
                .ReplaceField("{Speaker2Name}", speech2SpeakerName)
                .ReplaceField("{Speech2Type}", speech2SpeechType)
                .ReplaceField("{SpeakerIntroduction}", speakerIntroduction)
                .ReplaceField("{TableTopicsMaster}", meeting.TopicMasterName)
                .ReplaceField("{EvaluationMinutes}", config.EvaluationTimeMinutes.ToString())
                .ReplaceField("{EvaluationIntroduction}", evaluationIntroduction)
                .ReplaceField("{EvaluationTime}", evalTime)
                .ReplaceField("{Evaluator1Name}", meeting.Speech1.EvaluatorName)
                .ReplaceField("{Evaluator2Name}", evaluator2Name)
                .ReplaceField("{FunctionaryReportTime}", funcReportTime)
                .ReplaceField("{ListenerTime}", listenerTime)
                .ReplaceField("{MentorItemStyle}", mentorItemStyle)
                .ReplaceField("{MentorDetailStyle}", mentorDetailStyle)
                .ReplaceField("{MentorTime}", mentorTime)
                .ReplaceField("{MentorName}", meeting.MentorName)
                .ReplaceField("{POReturnTime}", poReturnTime);

            byte[] byteArray = Encoding.ASCII.GetBytes(agenda);
            MemoryStream stream = new MemoryStream(byteArray);

            return stream;
        }

        private DateTime DetermineTableTopicsEnd(DateTime minBackend, DateTime minTableTopics, DateTime maxTableTopics)
        {
            // The time must be the lesser of minBackend & maxTableTopics
            // unless that value is less than minTableTopics
            DateTime calculatedTime = minBackend.Min(maxTableTopics);
            return calculatedTime.Max(minTableTopics);
        }
    }
}
