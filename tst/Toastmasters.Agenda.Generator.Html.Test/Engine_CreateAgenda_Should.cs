using System;
using Xunit;
using TestHelperExtensions;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Agenda.Generator.Html.Test
{
    public class Engine_CreateAgenda_Should
    {
        [Fact]
        public void UseAVisibleStyleForTheMentorItemIfMentorIsSupplied()
        {
            string tag = string.Empty.GetRandom();
            string mentorName = string.Empty.GetRandom();
            string content1 = string.Empty.GetRandom();
            string content2 = string.Empty.GetRandom();

            string expected = $"{content1}<{tag} class=\"AgendaDetails\">{mentorName}<{tag}/>{content2}";
            string template = $"{content1}<{tag} class=\"{{MentorDetailsStyle}}\">{mentorName}<{tag}/>{content2}";

            AgendaConfig config = new Builders.AgendaConfigBuilder().Build();
            Club club = new Builders.ClubBuilder().Build();
            Meeting meeting = new Builders.MeetingBuilder().MentorName(mentorName).Build();

            var target = new Engine(template, string.Empty, string.Empty);
            var actual = target.CreateAgenda(config, club, meeting).AsString();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UseACollapsedStyleForTheMentorItemIfMentorIsNotSupplied()
        {
            string tag = string.Empty.GetRandom();
            string content1 = string.Empty.GetRandom();
            string content2 = string.Empty.GetRandom();

            string expected = $"{content1}<{tag} class=\"InactiveDetails\">mentor<{tag}/>{content2}";
            string template = $"{content1}<{tag} class=\"{{MentorDetailsStyle}}\">mentor<{tag}/>{content2}";

            AgendaConfig config = new Builders.AgendaConfigBuilder().Build();
            Club club = new Builders.ClubBuilder().Build();
            Meeting meeting = new Builders.MeetingBuilder().Build();

            var target = new Engine(template, string.Empty, string.Empty);
            var actual = target.CreateAgenda(config, club, meeting).AsString();
            Assert.Equal(expected, actual);
        }
    }
}
