using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Club
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public string PresidentName { get; set; }
        public string VPEducationName { get; set; }
        public string VPMembershipName { get; set; }
        public string VPPublicRelationsName { get; set; }
        public string SecretaryName { get; set; }
        public string TreasurerName { get; set; }
        public string SeargeantAtArmsName { get; set; }

        public string MeetingMessage { get; set; }

        public string WebsiteUrl { get; set; }
        public string EmailAddress { get; set; }
        public string SlackChannel { get; set; }

        public string MissionStatement { get; set; }

    }
}
