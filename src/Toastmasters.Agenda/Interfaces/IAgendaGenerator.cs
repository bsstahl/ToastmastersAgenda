using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Toastmasters.Agenda.Interfaces
{
    public interface IAgendaGenerator
    {
        System.IO.Stream CreateAgenda(Entities.AgendaConfig config, Entities.Club club, Entities.Meeting meeting);
    }
}
