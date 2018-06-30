using System;
using Xunit;
using TestHelperExtensions;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Agenda.Generator.Html.Test
{
    public class Engine_CreateAgenda_Should
    {
        [Fact]
        public void ReplaceTheStyleOfTheMentorItemIfMentorIsNotSupplied()
        {
            string tag = string.Empty.GetRandom();
            string expected = $"{string.Empty.GetRandom()}<{tag} class=\"InactiveDetails\">mentor<{tag}/>{string.Empty.GetRandom()}";
            string template = $"{string.Empty.GetRandom()}<{tag} class=\"{{MentorDetailsStyle}}\">mentor<{tag}/>{string.Empty.GetRandom()}";

            AgendaConfig config = new Builders.AgendaConfigBuilder().Build();
            Club club = new Builders.ClubBuilder().Build();
            Meeting meeting = new Builders.MeetingBuilder().Build();

            var target = new Engine(template, string.Empty, string.Empty);
            var actual = target.CreateAgenda(config, club, meeting).AsString();
            Assert.Equal(expected, actual);
        }
    }
}
