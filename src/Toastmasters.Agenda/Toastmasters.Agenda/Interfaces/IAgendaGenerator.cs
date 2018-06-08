using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Toastmasters.Agenda.Interfaces
{
    public interface IAgendaGenerator
    {
        void CreateAgenda(Entities.Meeting meeting, string destinationPath);
    }
}
