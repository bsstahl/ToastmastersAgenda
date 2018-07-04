using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Agenda.Entities;

namespace Toastmasters.Web.Models
{
    public class ConfigViewModel
    {
        public ConfigViewModel() { }
        public ConfigViewModel(Config config)
        {
            this.Verson = config.Verson;
            this.AgendaConfig = config.AgendaConfig;
            this.ClubConfig = config.ClubConfig;
        }

        public Single Verson { get; set; }
        public AgendaConfig AgendaConfig { get; set; }
        public Club ClubConfig { get; set; }

        public Config AsConfig()
        {
            return new Config()
            {
                AgendaConfig = this.AgendaConfig,
                ClubConfig = this.ClubConfig,
                Verson = this.Verson
            };
        }
    }
}
