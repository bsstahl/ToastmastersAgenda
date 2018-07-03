using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Builders
{
    public class ClubOfficerBuilder: Entities.Officers
    {
        public new ClubOfficerBuilder PresidentName(string name)
        {
            base.PresidentName = name;
            return this;
        }

        public new ClubOfficerBuilder VPEducationName(string name)
        {
            base.VPEducationName = name;
            return this;
        }

        public new ClubOfficerBuilder VPMembershipName(string name)
        {
            base.VPMembershipName = name;
            return this;
        }

        public new ClubOfficerBuilder VPPublicRelationsName(string name)
        {
            base.VPPublicRelationsName = name;
            return this;
        }

        public new ClubOfficerBuilder SecretaryName(string name)
        {
            base.SecretaryName = name;
            return this;
        }

        public new ClubOfficerBuilder TreasurerName(string name)
        {
            base.TreasurerName = name;
            return this;
        }

        public new ClubOfficerBuilder SeargeantAtArmsName(string name)
        {
            base.SeargeantAtArmsName = name;
            return this;
        }

        public ClubOfficerBuilder Defaults()
        {
            return this.PresidentName("Club President")
                .VPEducationName("Club VP Education")
                .VPMembershipName("Club VP Membership")
                .VPPublicRelationsName("Club VP PR")
                .SecretaryName("Club Secretary")
                .TreasurerName("Club Treasurer")
                .SeargeantAtArmsName("Sergeant-At-Arms");
        }

        public Entities.Officers Build()
        {
            return this;
        }
    }
}
