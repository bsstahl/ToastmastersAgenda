using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toastmasters.Web.Models
{
    public class AgendaDefaultsModel
    {
        public DayOfWeek MeetingDayOfWeek { get; set; }
        public Single MeetingStartTime { get; set; }

        public int MeetingLengthMinutes { get; set; }

        public IEnumerable<string> OfficerNames { get; set; }


        public DateTime MeetingStartDateTime()
        {
            // Using the MeetingDayOfWeek and MeetingStartTime, calculate
            // the next meeting date and time to use in the view
            int dowDelta = (Int32)this.MeetingDayOfWeek - (Int32)DateTime.Now.DayOfWeek;
            if (dowDelta < 0)
                dowDelta = 7 + dowDelta;

            return DateTime.Now.Date.AddDays(dowDelta).AddHours(this.MeetingStartTime);
        }
    }
}
