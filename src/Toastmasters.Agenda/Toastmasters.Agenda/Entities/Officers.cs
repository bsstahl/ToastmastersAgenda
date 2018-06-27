using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Officers
    {
        public string PresidentName { get; set; }
        public string VPEducationName { get; set; }
        public string VPMembershipName { get; set; }
        public string VPPublicRelationsName { get; set; }
        public string SecretaryName { get; set; }
        public string TreasurerName { get; set; }
        public string SeargeantAtArmsName { get; set; }


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
