using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Builders
{
    public class ClubBuilder: Entities.Club
    {
        public ClubBuilder()
        {
            this.Officers = new Entities.Officers();
        }

        public Entities.Club Build()
        {
            return this;
        }
    }
}
