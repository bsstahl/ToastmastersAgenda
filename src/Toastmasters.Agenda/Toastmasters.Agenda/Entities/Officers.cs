using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Officers
    {
        public Officers(bool loadDefaults = false)
        {
            if (loadDefaults)
                LoadDefaults();
        }

        public string PresidentName { get; set; }
        public string VPEducationName { get; set; }
        public string VPMembershipName { get; set; }
        public string VPPublicRelationsName { get; set; }
        public string SecretaryName { get; set; }
        public string TreasurerName { get; set; }
        public string SeargeantAtArmsName { get; set; }


        private void LoadDefaults()
        {
            this.PresidentName = "Club President";
            this.VPEducationName = "Club VP Education";
            this.VPMembershipName = "Club VP Membership";
            this.VPPublicRelationsName = "Club VP PR";
            this.SecretaryName = "Club Secretary";
            this.TreasurerName = "Club Treasurer";
            this.SeargeantAtArmsName = "Sergeant-At-Arms";
        }

        public IEnumerable<String> AsEnumerable()
        {
            return new List<string>()
                {
                    this.PresidentName,
                    this.VPEducationName,
                    this.VPMembershipName,
                    this.VPPublicRelationsName,
                    this.SecretaryName,
                    this.TreasurerName,
                    this.SeargeantAtArmsName
                };
        }
    }
}
