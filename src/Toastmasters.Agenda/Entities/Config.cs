using System;
using System.Collections.Generic;
using System.Text;

namespace Toastmasters.Agenda.Entities
{
    public class Config
    {
        public Single Verson { get; set; }
        public AgendaConfig AgendaConfig { get; set; }
        public Club ClubConfig { get; set; }
    }
}
